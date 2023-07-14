using BusinessObjects.Models;
using DataAccessLayers.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        public OrderServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public bool AddAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddOrderInRoute(OrderInRoute orderInRoute)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Order GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int GetLastIDinOrderInRoutes()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> UnProcessingOrder()
        {
            throw new NotImplementedException();
        }

        public bool Update(Order order)
        {
            throw new NotImplementedException();
        }

        public bool UpdatetoProcessingState(int orderID)
        {
            throw new NotImplementedException();
        }
    }
}
