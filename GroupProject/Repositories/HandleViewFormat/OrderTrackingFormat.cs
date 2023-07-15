using ModelsV6.DAOs;
using ModelsV6.DTOs.TrackingOrderObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.HandleViewFormat
{
    public class OrderTrackingFormat
    {
        BirdTransportationSystemContext _context = new BirdTransportationSystemContext();
       public ReceivingShipperInfo getReceivingShipperInfoByOrderID(int orderID)
        {
            ReceivingShipperInfo result = (from order in _context.Orders
                         join orderinRoute in _context.OrderInRoutes on order.OrderId equals orderinRoute.OrderId
                         join route in _context.Routes on orderinRoute.RouteId equals route.RouteId
                         join shipper in _context.Shippers on route.ShipperId equals shipper.ShipperId
                         where order.OrderId == orderID && route.Type == "Receiving"
                         select new ReceivingShipperInfo
                         {
                             ReceivingAddress = order.ReceivingAddress,
                             ShipperEmail = shipper.Email,
                             ShipperName = shipper.ShipperName,
                             ShipperPhone = shipper.PhoneNumber,
                             ShipperVehicle = shipper.VehicleType,
                             RouteStatus = orderinRoute.Status
                             

                         }).FirstOrDefault();
            return (ReceivingShipperInfo)result;
        }


        public SendingShipperInfo getSendingShipperInfoByOrderID(int orderID)
        {
            SendingShipperInfo result = (from order in _context.Orders
                         join orderinRoute in _context.OrderInRoutes on order.OrderId equals orderinRoute.OrderId
                         join route in _context.Routes on orderinRoute.RouteId equals route.RouteId
                         join shipper in _context.Shippers on route.ShipperId equals shipper.ShipperId
                         where order.OrderId == orderID && route.Type == "Sending"
                         select new SendingShipperInfo
                         {
                             SendingAddress = order.SendingAddress,
                             ShipperEmail = shipper.Email,
                             ShipperName = shipper.ShipperName,
                             ShipperPhone = shipper.PhoneNumber,
                             ShipperVehicle = shipper.VehicleType,
                             RouteStatus =  orderinRoute.Status

                         }).AsQueryable().FirstOrDefault();
            return result;
        }

        public List<WarehouseTrackingInfo> getWarehouseTrackingInfo(int orderID)
        {
            var result = (from order in _context.Orders
                         join trackingorder in _context.TrackingOrders on order.OrderId equals  trackingorder.OrderId
                         join warehouse in _context.Warehouses on  trackingorder.WarehouseId equals warehouse.WarehouseId
                         where trackingorder.OrderId == orderID
                         select new WarehouseTrackingInfo
                         {
                             WarehouseName = warehouse.WarehouseName,
                             WarhouseLocation = warehouse.Location,
                             SequenceNumber = (int)trackingorder.SequenceNumber,
                             WarehouseStatus = trackingorder.TrackingStatus
                             
                         }).OrderBy(x => x.SequenceNumber).ToList();

            return result;  
        }
    }
}
