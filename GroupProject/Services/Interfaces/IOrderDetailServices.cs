using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOrderDetailServices
    {
        bool AddNewOrder(Order order);
        List<Order> GetAllOrderByCusotmetID(int id);
        bool CancelOrderbyOrderID(int id);
        Order GetOrderById(int id);
        int GetLastOrder();
        List<OrderDetail> GetOrderDetailByOrderId(int id);
        bool Remove(int id);
        bool UpdateOrder(Order order);
        int GetLastOrderDetailId();
        Task<bool> AddNewOrderDetail(OrderDetail orderDetail);
    }
}
