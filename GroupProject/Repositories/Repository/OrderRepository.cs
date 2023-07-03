using Microsoft.EntityFrameworkCore;
using ModelsV4.DAOs;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repoository
{
    public class OrderRepository : IOrderRepository
    {
        private static BirdTransportationSystemContext _context;
        public OrderRepository(BirdTransportationSystemContext context)
        {
            _context = context;
        }
        public Task<bool> AddAsync(Order order)
        {
            throw new NotImplementedException();
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
    }
}
