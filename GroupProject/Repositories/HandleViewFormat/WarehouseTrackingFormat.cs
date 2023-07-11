using ModelsV5.DAOs;
using ModelsV5.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.HandleViewFormat
{
    public class WarehouseTrackingFormat
    {
        public BirdTransportationSystemContext _context;

        public WarehouseTrackingFormat(BirdTransportationSystemContext context)
        {
            _context = context;
        }

        public List<OrderInWarehouse> orderInWarehouses(int warehouseManagerId)
        {
            var result = (from order in _context.Orders
                          join trackingorder in _context.TrackingOrders on order.OrderId equals trackingorder.OrderId
                          join Warehouse in _context.Warehouses on trackingorder.WarehouseId equals Warehouse.WarehouseId
                          join warehouseManager1 in _context.WarehouseManagers on Warehouse.WarehouseManagerId equals warehouseManager1.WarehouseManagerId
                          where warehouseManager1.WarehouseManagerId == warehouseManagerId
                          select new OrderInWarehouse
                          {
                              OrderId = order.OrderId,
                              Note = order.Note,
                              receivingAddress = order.ReceivingAddress,
                              sendingAddress = order.SendingAddress,
                              sequenceNumber = (int)trackingorder.SequenceNumber,
                              TrackingStatus = trackingorder.TrackingStatus,
                              TrackingOrderId = trackingorder.TrackingOrderId
                          }).ToList();
            return result;
        }
    }
}
