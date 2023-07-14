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
        public bool AddAsync(Order order) => _orderRepository.AddAsync(order);

        public Task<bool> AddOrderInRoute(OrderInRoute orderInRoute) => _orderRepository.AddOrderInRoute(orderInRoute);

        public Task<IEnumerable<Order>> GetAllAsync() => _orderRepository.GetAllAsync();

        public Order GetByIdAsync(int id) => _orderRepository.GetByIdAsync(id);

        public int GetLastIDinOrderInRoutes() => _orderRepository.GetLastIDinOrderInRoutes();

        public bool Remove(int id) => _orderRepository.Remove(id);

        public List<Order> UnProcessingOrder() => _orderRepository.UnProcessingOrder();

        public bool Update(Order order) => _orderRepository.Update(order);

        public bool UpdatetoProcessingState(int orderID) => _orderRepository.UpdatetoProcessingState(orderID);
    }
}
