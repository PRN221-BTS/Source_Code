using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelsV5.DAOs;
using Repositories.IRepository;

namespace ViewModel.Pages.Warehouses
{
    public class ViewOrderAtWarehouseModel : PageModel
    {
        private readonly ModelsV5.DAOs.BirdTransportationSystemContext _context;
        private IWarehouseRepository _warehouseRepository;

        public ViewOrderAtWarehouseModel(ModelsV5.DAOs.BirdTransportationSystemContext context, IWarehouseRepository warehouseRepository)
        {
            _context = context;
            _warehouseRepository = warehouseRepository;
        }
        public IList<Warehouse> Warehouses { get; set; }
        public IList<TrackingOrder> TrackingOrders { get; set; }
        public IList<Order> Orders { get; set; }
        public int WarehouseId { get; set; }
        public int SequenceNumber { get; set; }

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
                // Get the tracking orders for the current order
                var trackingOrders = _context.TrackingOrders
                    .Where(trackingOrder => trackingOrder.OrderId == order.OrderId)
                    .ToList();

                for (int i = 0; i < trackingOrders.Count; i++)
                {
                    trackingOrders[i].SequenceNumber = i + 1;
                }

                order.TrackingOrders = trackingOrders;
            }
        }

        public IActionResult OnPostMarkAsDelivered(int trackingOrderId)
        {
            var trackingOrder = _context.TrackingOrders.Find(trackingOrderId);

            if (trackingOrder != null && trackingOrder.TrackingStatus == "Delivery")
            {
                trackingOrder.TrackingStatus = "Shipped";
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
