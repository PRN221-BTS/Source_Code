using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using ModelsV5.DAOs;
using ModelsV5.DTOs;
using Repositories.HandleViewFormat;
using Repositories.IRepository;
using Route = ModelsV5.DAOs.Route;

namespace ViewModel.Pages.LogisticsHandle
{
    public class HandleSingleOrderModel : PageModel
    {
       
    
        private static IWarehouseRepository _warehouseRepo;
        private static IOrderRepository _orderRepository;   
        private static IShipperRepository _shipperRepo;
        private static ShipperViewFormat _viewFormat;
        private static IRouteRepository _routeRepository;
        public List<Shipper> receivingShipperList;
        
        public List<Shipper> sendingShipperList;

        public List<WarehouseCart>? warehouseCartList { get; set; }

       
        [BindProperty]
        public List<InformationShipper> shippersView { get ; set; }
        
        
        [BindProperty]
        public List<Warehouse> warehouse { get; set; }
        
        public List<Shipper> shippers { get; set; }

        [BindProperty]
        public Order order { get; set; }
        
        public InformationShipper informationShipper { get; set; }
     
        public HandleSingleOrderModel(IWarehouseRepository warehouseRepo,IOrderRepository orderRepository,IShipperRepository shipperRepo,ShipperViewFormat viewFormat,IRouteRepository routeRepository)
        {
            
            _viewFormat = viewFormat;
            _warehouseRepo = warehouseRepo;
            _orderRepository = orderRepository;
            _shipperRepo = shipperRepo;
            _routeRepository = routeRepository;
        }
        public void OnGet(int id)
        {
            CallObjectFromJson();
            TempData["id"] = id;
            order = _orderRepository.GetByIdAsync(id);
            warehouse = _warehouseRepo.GetAllAsync();
           
        }
       
        public IActionResult OnPostInfoShipper(string warehouseKeyWord) 
        {
            receivingShipperList = SessionHelper.GetObjectFromJson<List<Shipper>>(HttpContext.Session, "ReceivingShippers");
            sendingShipperList = SessionHelper.GetObjectFromJson<List<Shipper>>(HttpContext.Session, "SendingShippers");
            shippers = _shipperRepo.GetShippersByWarehouseID(int.Parse(warehouseKeyWord));
            return Page();
        }

        public IActionResult OnPostAddShipper(string id,string ShipperType)
        {
            var shipper = _shipperRepo.GetShipperById(int.Parse(id));
            if(ShipperType == "Receive")
            {
                receivingShipperList = SessionHelper.GetObjectFromJson<List<Shipper>>(HttpContext.Session, "ReceivingShippers");
                if(receivingShipperList == null)
                {
                    receivingShipperList = new List<Shipper>();
                    receivingShipperList.Add(shipper);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "ReceivingShippers", receivingShipperList);
                }else
                {
                    receivingShipperList.Add(shipper);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "ReceivingShippers", receivingShipperList);
                }
            }
            if(ShipperType == "Send")
            {
                sendingShipperList = SessionHelper.GetObjectFromJson<List<Shipper>>(HttpContext.Session, "SendingShippers");
                if (sendingShipperList == null)
                {
                    sendingShipperList = new List<Shipper>();
                    sendingShipperList.Add(shipper);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "SendingShippers", sendingShipperList);
                }else
                {
                    sendingShipperList.Add(shipper);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "SendingShippers", sendingShipperList);
                }
            }
            receivingShipperList = SessionHelper.GetObjectFromJson<List<Shipper>>(HttpContext.Session, "ReceivingShippers");
            sendingShipperList = SessionHelper.GetObjectFromJson<List<Shipper>>(HttpContext.Session, "SendingShippers");
            return Page();
        }

        public IActionResult OnPostAddWarehouseToRoute(int WarehouseId,int sequenceNumberWarehouse)
        {

             var warehouseFinding = _warehouseRepo.GetByIdAsync(WarehouseId);
           
            warehouseCartList = SessionHelper.GetObjectFromJson<List<WarehouseCart>>(HttpContext.Session, "ListWarehouseinRoute");
          
            if (warehouseCartList == null) {
                warehouseCartList = new List<WarehouseCart>();
                warehouseCartList.Add( new WarehouseCart
                {
                    SequenceNumber = sequenceNumberWarehouse,
                    WarehouseID = warehouseFinding.WarehouseId,
                    WarehouseLocation = warehouseFinding.Location,
                    WarehouseName = warehouseFinding.WarehouseName
                } );
                SessionHelper.SetObjectAsJson(HttpContext.Session, "ListWarehouseinRoute", warehouseCartList);
            } else
            {
                if (warehouseCartList.FirstOrDefault(x => x.SequenceNumber == sequenceNumberWarehouse) is not null)
                {
                    TempData["ErrorInSequenceNumber"] = "have  sequence number in this array ";
                    return Page();
                }
                else
                {

                    TempData["ErrorInSequenceNumber"] = null;
                }
                warehouseCartList.Add(new WarehouseCart()
                {
                    SequenceNumber = sequenceNumberWarehouse,
                    WarehouseID = warehouseFinding.WarehouseId,
                    WarehouseLocation = warehouseFinding.Location,
                    WarehouseName = warehouseFinding.WarehouseName
                });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "ListWarehouseinRoute", warehouseCartList.OrderBy(x => x.SequenceNumber));
            }


            warehouseCartList = SessionHelper.GetObjectFromJson<List<WarehouseCart>>(HttpContext.Session, "ListWarehouseinRoute");
            return Page();
        }

        public IActionResult OnGetAddRoute()
        {
            CallObjectFromJson();
            //With receiving and sending list just need one Shipper 
       if(receivingShipperList.Count() > 1 && sendingShipperList.Count > 1)
            {
                TempData["ErrorInCount"] = "have  sequence number in this array ";
                return Page();
            }
            //Receiving object can use automapper
          //Can calculate distance so set default get distance to calculate price 
            Route receivingRoute = new Route { 
            Distance =500,
            Price = 500,
            RouteId = _routeRepository.GetLastValueObject(),
            ShipperId = receivingShipperList.FirstOrDefault().ShipperId
            
            };
            AddNewRoute(receivingRoute);

            //Sending object can use automapper
            Route sendingRoute = new Route
            {
                Distance = 500,
                Price = 500,
                RouteId = _routeRepository.GetLastValueObject(),
                ShipperId = receivingShipperList.FirstOrDefault().ShipperId

            };
            AddNewRoute(sendingRoute);


            for(int i = 0; i < warehouseCartList.Count;i++)
            {
                if (warehouseCartList[i].SequenceNumber == 1)
                {
                    TrackingOrder trackingOrder = new TrackingOrder { 
                    SequenceNumber = warehouseCartList[i].SequenceNumber,
                    ActualDeliveryDate = DateTime.UtcNow,
                    EstimateDeliveryDate = DateTime.UtcNow,
                    OrderId = int.Parse(TempData["id"].ToString()),
                    TrackingStatus = TrackingState.Delivery.ToString(),
                    TrackingOrderId = _warehouseRepo.GetLastObjectInTrackingOrder(),
                    WarehouseId = warehouseCartList[i].WarehouseID,
                    
                    };  
                    _warehouseRepo.AddTrackingOrder(trackingOrder);
                }
                TrackingOrder trackingOrderOther = new TrackingOrder
                {
                    SequenceNumber = warehouseCartList[i].SequenceNumber,
                    ActualDeliveryDate = DateTime.UtcNow,
                    EstimateDeliveryDate = DateTime.UtcNow,
                    OrderId = int.Parse(TempData["id"].ToString()),
                    TrackingStatus = TrackingState.Delivery.ToString(),
                    TrackingOrderId = _warehouseRepo.GetLastObjectInTrackingOrder(),
                    WarehouseId = warehouseCartList[i].WarehouseID,

                };
                _warehouseRepo.AddTrackingOrder(trackingOrderOther);

            }
            return RedirectToPage("/LogisticsHandle/OrderBatchManagement");
        }
        private  void CallObjectFromJson()
        {
            receivingShipperList = SessionHelper.GetObjectFromJson<List<Shipper>>(HttpContext.Session, "ReceivingShippers");
            sendingShipperList = SessionHelper.GetObjectFromJson<List<Shipper>>(HttpContext.Session, "SendingShippers");
            warehouseCartList = SessionHelper.GetObjectFromJson<List<WarehouseCart>>(HttpContext.Session, "ListWarehouseinRoute");
        }


        private bool AddNewRoute(Route route)
        {
            _routeRepository.AddNewRoute(route);
            return true;
        }
        //public IActionResult OnPostAddShipper() { }
    }
}
