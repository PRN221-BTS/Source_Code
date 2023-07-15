using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelsV6.DAOs;
using ModelsV6.DTOs;
using Repositories.HandleViewFormat;
using Repositories.IRepository;

namespace ViewModel.Pages.Warehouses
{
    public class ViewOrderAtWarehouseModel : PageModel
    {
        private readonly ModelsV6.DAOs.BirdTransportationSystemContext _context;
        private IWarehouseRepository _warehouseRepository;
        private static WarehouseTrackingFormat _trackingFormat;
        private static ITrackingOrderRepository _trackingOrderRepo;
        public ViewOrderAtWarehouseModel(ModelsV6.DAOs.BirdTransportationSystemContext context, IWarehouseRepository warehouseRepository, WarehouseTrackingFormat trackingFormat, ITrackingOrderRepository trackingOrderRepo)
        {
            _context = context;
            _warehouseRepository = warehouseRepository;
            _trackingFormat = trackingFormat;
            _trackingOrderRepo = trackingOrderRepo;
        }
        public IList<Warehouse> Warehouses { get; set; }
        public IList<TrackingOrder> TrackingOrders { get; set; }
        public IList<Order> Orders { get; set; }
        public int WarehouseId { get; set; }
        public int SequenceNumber { get; set; }
        public List<OrderInWarehouse> orderInWarehouses { get; set; }

        public void OnGet()
        {
            Warehouse warehouse = _warehouseRepository.getWarehouseInfoByWarehouseManagerID(int.Parse(HttpContext.Session.GetString("WarehouseID")));
            WarehouseId = warehouse.WarehouseId;

            Warehouses = _context.Warehouses.ToList();
            TrackingOrders = _context.TrackingOrders.ToList();

            Orders = _context.Orders
                .Include(order => order.TrackingOrders)
                .Where(order => order.TrackingOrders.Any(trackingOrder => trackingOrder.WarehouseId == WarehouseId))
                .Where(order => order.Status == "Processing")
                .ToList();

            foreach (var order in Orders)
            {
                //  Get the tracking orders for the current order
                var trackingOrders = _context.TrackingOrders
                  .Where(trackingOrder => trackingOrder.OrderId == order.OrderId)
                    .ToList();

                for (int i = 0; i < trackingOrders.Count; i++)
                {
                    trackingOrders[i].SequenceNumber = i + 1;
                }

                order.TrackingOrders = trackingOrders;
            }
            
            orderInWarehouses= _trackingFormat.orderInWarehouses(int.Parse(HttpContext.Session.GetString("WarehouseID")));
            for (int i = 0; i < orderInWarehouses.Count(); i++)
            {
                if (CheckSequenceNumber(orderInWarehouses[i].OrderId, orderInWarehouses[i].sequenceNumber))
                {
                    orderInWarehouses[i].LastWarehouse = true;
                }
                else
                {
                    orderInWarehouses[i].LastWarehouse = false;
                }
            }

        }

        public IActionResult OnPostMarkAsDelivered(int trackingOrderId)
        {
            _trackingOrderRepo.UpdateShippedStateInTrackingOrderToInWarehouseState(trackingOrderId);
            return RedirectToPage();
        }


        public IActionResult OnPostSendOrderToCustomer(int trackingOrderId)
        {
            _trackingOrderRepo.SendOrderToCustomer(trackingOrderId);    
            return RedirectToPage();
        }

        public ActionResult OnPostAddToWarehouse(int trackingOrderId)
        {

            _trackingOrderRepo.UpdateInWarehouseStateInTrackingOrderWithDeliveryState(trackingOrderId);
            return RedirectToPage();
        }

        public ActionResult OnPostSendWarehouseToNextWarehouse(int trackingOrderId)
        {
            _trackingOrderRepo.UpdateComingStateInTrackingOrder(trackingOrderId);
            return RedirectToPage();
        }

        public bool CheckSequenceNumber(int orderId, int sequencenumber)
        {
            var listTrackingOrder = _context.TrackingOrders.OrderByDescending(x => x.SequenceNumber).FirstOrDefault(x => x.OrderId == orderId);
            if (listTrackingOrder.SequenceNumber == sequencenumber)
            {
                return true;
            }

            return false;
        }
    }
}
