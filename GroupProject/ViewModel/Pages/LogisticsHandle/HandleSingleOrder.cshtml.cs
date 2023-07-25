using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using ModelsV6.DAOs;
using ModelsV6.DTOs;
using ModelsV6.DTOs.State;
using Repositories.HelperRepository.HandleViewFormat;
using Repositories.IRepository;
using Route = ModelsV6.DAOs.Route;

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
         
            TempData["id"] = id;
            order = _orderRepository.GetByIdAsync(id);
            warehouse = _warehouseRepo.GetAllAsync();
            CallObjectFromJson();


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
            warehouse = _warehouseRepo.GetAllAsync();
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

            warehouse = _warehouseRepo.GetAllAsync();
            warehouseCartList = SessionHelper.GetObjectFromJson<List<WarehouseCart>>(HttpContext.Session, "ListWarehouseinRoute");
            CallObjectFromJson();
            return Page();
        }

        public async Task<IActionResult> OnGetAddRoute()
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
            ShipperId = receivingShipperList.FirstOrDefault().ShipperId,
            Type = RouteState.Receiving.ToString(),
            
            };
            OrderInRoute orderInRouteInReceivingRoute = new OrderInRoute
            {
                OrderInRouteId = _orderRepository.GetLastIDinOrderInRoutes() + 1,
                OrderId = int.Parse(TempData["id"].ToString()),
                RouteId = receivingRoute.RouteId
                ,Status = OrderInRouteState.Coming.ToString()
            };
         await   AddNewRoute(receivingRoute);
          await  _orderRepository.AddOrderInRoute(orderInRouteInReceivingRoute);

            //Sending object can use automapper
            Route sendingRoute = new Route
            {
                Distance = 500,
                Price = 500,
                RouteId = _routeRepository.GetLastValueObject(),
                ShipperId = sendingShipperList.FirstOrDefault().ShipperId,
                Type = RouteState.Sending.ToString()
               

            };
            OrderInRoute orderInRouteInSendingRoute = new OrderInRoute
            {
                OrderInRouteId = _orderRepository.GetLastIDinOrderInRoutes() + 1,
                OrderId = int.Parse(TempData["id"].ToString()),
                RouteId = sendingRoute.RouteId
               ,Status  = OrderInRouteState.Pending.ToString() 
                
            };
          await  AddNewRoute(sendingRoute);
         await   _orderRepository.AddOrderInRoute(orderInRouteInSendingRoute);



            for(int i = 0; i < warehouseCartList.Count;i++)
            {
                if (warehouseCartList[i].SequenceNumber == 1)
                {
                    TrackingOrder trackingOrder = new TrackingOrder
                    {
                        SequenceNumber = warehouseCartList[i].SequenceNumber,
                        ActualDeliveryDate = DateTime.UtcNow,
                        EstimateDeliveryDate = DateTime.UtcNow,
                        OrderId = int.Parse(TempData["id"].ToString()),
                        TrackingStatus = TrackingState.Delivery.ToString(),
                        TrackingOrderId = _warehouseRepo.GetLastObjectInTrackingOrder() + 1,
                        WarehouseId = warehouseCartList[i].WarehouseID,

                    };
                    await _warehouseRepo.AddTrackingOrder(trackingOrder);
                }
                else
                {

                    TrackingOrder trackingOrderOther = new TrackingOrder
                    {
                        SequenceNumber = warehouseCartList[i].SequenceNumber,
                        ActualDeliveryDate = DateTime.UtcNow,
                        EstimateDeliveryDate = DateTime.UtcNow,
                        OrderId = int.Parse(TempData["id"].ToString()),
                        TrackingStatus = TrackingState.InRoute.ToString(),
                        TrackingOrderId = _warehouseRepo.GetLastObjectInTrackingOrder() + 1,
                        WarehouseId = warehouseCartList[i].WarehouseID,

                    };
                    await _warehouseRepo.AddTrackingOrder(trackingOrderOther);
                }
            }

            _orderRepository.UpdatetoProcessingState(int.Parse(TempData["id"].ToString()));
            SessionHelper.SetObjectAsJson(HttpContext.Session, "SendingShippers", null);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ReceivingShippers", null);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ListWarehouseinRoute", null);

            return RedirectToPage("/LogisticsHandle/OrderBatchManagement");
        }
        private  void CallObjectFromJson()
        {
            
            receivingShipperList = SessionHelper.GetObjectFromJson<List<Shipper>>(HttpContext.Session, "ReceivingShippers");
            sendingShipperList = SessionHelper.GetObjectFromJson<List<Shipper>>(HttpContext.Session, "SendingShippers");
            warehouseCartList = SessionHelper.GetObjectFromJson<List<WarehouseCart>>(HttpContext.Session, "ListWarehouseinRoute");
            warehouse = _warehouseRepo.GetAllAsync();
        }


        private  async Task<bool> AddNewRoute(Route route)
        {
        await    _routeRepository.AddNewRoute(route);
            return true;
        }
        //public IActionResult OnPostAddShipper() { }
    }
}
