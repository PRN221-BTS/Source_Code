using ModelsV6.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IOrderDetailRepository
    {
        bool AddNewOrder(Order order);
        List<Order> GetAllOrderByCusotmetID(int id);
        List<OrderDetail> GetOrderDetailByOrderId(int id);
        bool Remove(int id);
        bool UpdateOrder(Order order);

        int GetLastOrder();

        public Order GetOrderById(int id);

        public int GetLastOrderDetailId();

        public bool CancelOrderbyOrderID(int id);

        public Task<bool> AddNewOrderDetail(OrderDetail orderDetail);
    }
}
