using Model.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IOrderRepository
    {
        Task<bool> AddAsync(Order order);
        Task<IEnumerable<Order>> GetAllAsync();
        Order GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(Order order);
        public List<Order> UnProcessingOrder();

    }
}
