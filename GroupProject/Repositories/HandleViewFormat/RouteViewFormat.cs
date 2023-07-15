using Microsoft.EntityFrameworkCore;
using ModelsV6.DAOs;
using ModelsV6.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.HandleViewFormat
{
    public class RouteViewFormat
    {
        private static BirdTransportationSystemContext _context;

        public RouteViewFormat(BirdTransportationSystemContext context)
        {
            _context = context;
        }
        public List<ReceivingOrder> receivingOrders(int id)
        {


            var result = (from order in _context.Orders
                         join orderRoute in _context.OrderInRoutes on order.OrderId equals orderRoute.OrderId
                         join route in _context.Routes on orderRoute.RouteId equals route.RouteId
                         where route.ShipperId == id &&  route.Type ==  "Receiving"
                         select new ReceivingOrder {

                             Distance = (decimal)route.Distance,
                             Note = order.Note,
                             Price = (decimal)route.Price,
                             ReceivingAddress = order.ReceivingAddress,
                             Type = route.Type,
                             RouteID = route.RouteId
                             ,OrderInRoutes = orderRoute.OrderInRouteId

                         }).ToList();
       

            return result;

        }

        public List<SendingOrder> sendingOrders(int id)
        {

            var result = (from order in _context.Orders
                          join orderRoute in _context.OrderInRoutes on order.OrderId equals orderRoute.OrderId
                          join route in _context.Routes on orderRoute.RouteId equals route.RouteId
                          where route.ShipperId == id && route.Type == "Sending"
                          select new SendingOrder
                          {

                              Distance = (decimal)route.Distance,
                              Note = order.Note,
                              Price = (decimal)route.Price,
                              SendingAddress = order.SendingAddress,
                              Type = route.Type,
                              RouteID = route.RouteId,
                              OrderInRoutes = orderRoute.OrderInRouteId
                          }).ToList();
            return result;

        }
    }
}
