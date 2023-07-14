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
    public class OrderDetailServices : IOrderDetailServices
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailServices(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public bool AddNewOrder(Order order) => _orderDetailRepository.AddNewOrder(order);

        public Task<bool> AddNewOrderDetail(OrderDetail orderDetail) => _orderDetailRepository.AddNewOrderDetail(orderDetail);

        public bool CancelOrderbyOrderID(int id) => _orderDetailRepository.CancelOrderbyOrderID(id);

        public List<Order> GetAllOrderByCusotmetID(int id) => _orderDetailRepository.GetAllOrderByCusotmetID(id);

        public int GetLastOrder() => _orderDetailRepository.GetLastOrder();

        public int GetLastOrderDetailId() => _orderDetailRepository.GetLastOrderDetailId();

        public Order GetOrderById(int id) => _orderDetailRepository.GetOrderById(id);

        public List<OrderDetail> GetOrderDetailByOrderId(int id) => _orderDetailRepository.GetOrderDetailByOrderId(id);

        public bool Remove(int id) => _orderDetailRepository.Remove(id);

        public bool UpdateOrder(Order order) => _orderDetailRepository.UpdateOrder(order);
    }
}
