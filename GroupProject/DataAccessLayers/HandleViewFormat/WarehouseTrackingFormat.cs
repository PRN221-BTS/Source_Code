using BusinessObjects.Models;
using BusinessObjects.DTOs;
using BusinessObjects.DTOs.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers.HandleViewFormat
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


        public  OrderInRoute getOrderInRouteByTrackingOrderID(int trackingOrderID,string orderType,string orderinrouteStatus)
        {
           OrderInRoute result = (from trackingorder in _context.TrackingOrders
                         join order in _context.Orders on trackingorder.OrderId equals order.OrderId
                         join orderinroute in _context.OrderInRoutes on order.OrderId equals orderinroute.OrderId
                         join warehouse in _context.Warehouses on trackingorder.WarehouseId equals warehouse.WarehouseId
                         join shipper in _context.Shippers on warehouse.WarehouseId equals shipper.WarehouseId
                         join route in _context.Routes on shipper.ShipperId equals route.ShipperId
                         where trackingorder.TrackingOrderId == trackingOrderID && orderinroute.Status == orderinrouteStatus && route.Type == orderType
                         select new OrderInRoute
                         {
                             OrderInRouteId = orderinroute.OrderInRouteId,
                             OrderId = orderinroute.OrderId,
                             RouteId = orderinroute.RouteId,
                             Status = orderinroute.Status,
                         }).FirstOrDefault();

            return result;
        }

  

        
    }
}
