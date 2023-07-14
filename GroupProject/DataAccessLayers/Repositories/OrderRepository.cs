using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using BusinessObjects.DTOs.State;
using DataAccessLayers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private static BirdTransportationSystemContext _context;
        public OrderRepository(BirdTransportationSystemContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Order GetByIdAsync(int id) => _context.Orders.FirstOrDefault(x=> x.OrderId == id);
        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
        public bool Update(Order order)
        {
            throw new NotImplementedException();
        }
        public List<Order> UnProcessingOrder() => _context.Orders.Where(x => x.Status == "UnProcessing").ToList();
        public bool AddAsync(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();
            return true;
        }
        public int GetLastIDinOrderInRoutes() => _context.OrderInRoutes.OrderByDescending(x => x.OrderInRouteId).FirstOrDefault().OrderInRouteId;
        public async Task<bool> AddOrderInRoute(OrderInRoute orderInRoute)
        {
            _context.OrderInRoutes.Add(orderInRoute);
           await _context.SaveChangesAsync(); 
            return true;
        }
        public bool UpdatetoProcessingState(int orderID)
        {
            _context = new BirdTransportationSystemContext();
            Order order = GetByIdAsync(orderID);
            order.Status = TrackingState.Processing.ToString();
            _context.SaveChanges();
            return true;
        }
    }
}
