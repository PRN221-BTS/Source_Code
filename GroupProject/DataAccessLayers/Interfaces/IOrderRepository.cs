using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers.Interfaces
{
    public interface IOrderRepository
    {
        bool AddAsync(Order order);
        Task<IEnumerable<Order>> GetAllAsync();
        Order GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(Order order);
        public List<Order> UnProcessingOrder();

        public int GetLastIDinOrderInRoutes();

        public Task<bool> AddOrderInRoute(OrderInRoute orderInRoute);

        bool UpdatetoProcessingState(int orderID);

    }
}
