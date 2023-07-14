using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOrderServices
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Order GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(Order order);
        List<Order> UnProcessingOrder();
        bool AddAsync(Order order);
        int GetLastIDinOrderInRoutes();
        Task<bool> AddOrderInRoute(OrderInRoute orderInRoute);
        bool UpdatetoProcessingState(int orderID);
    }
}
