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
        public bool AddNewOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddNewOrderDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public bool CancelOrderbyOrderID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrderByCusotmetID(int id)
        {
            throw new NotImplementedException();
        }

        public int GetLastOrder()
        {
            throw new NotImplementedException();
        }

        public int GetLastOrderDetailId()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> GetOrderDetailByOrderId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
