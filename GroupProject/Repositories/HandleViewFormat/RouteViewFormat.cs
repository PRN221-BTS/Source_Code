using Microsoft.EntityFrameworkCore;
using ModelsV4.DAOs;
using ModelsV4.DTOs;
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
       public List<ReceivingOrder> receivingOrders(int id) { 
       
            var result = _context.Orders.
                        Include(x => x.Route).
                        Where(x => x.Route.ShipperId == id).
                        Select(x => new ReceivingOrder
                        {
                            Distance = (decimal)x.Route.Distance,
                            Note = x.Note,
                            Price = (decimal)x.Route.Price,
                            ReceivingAddress = x.ReceivingAddress,
                            RouteID = x.Route.RouteId,
                            Type = x.Route.Type

                        }).ToList();
            return result;
        
        }

   public     List<SendingOrder> sendingOrders(int id)
        {

            var result = _context.Orders.
                        Include(x => x.Route).
                        Where(x => x.Route.ShipperId == id).
                        Select(x => new SendingOrder
                        {
                            Distance = (decimal)x.Route.Distance,
                            Note = x.Note,
                            Price = (decimal)x.Route.Price,
                            SendingAddress = x.SendingAddress,
                            RouteID = x.Route.RouteId,
                            Type = x.Route.Type

                        }).ToList();
            return result;

        }
    }
}
