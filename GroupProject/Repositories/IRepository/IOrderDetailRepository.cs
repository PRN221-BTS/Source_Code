using Model.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IOrderDetailRepository
    {
        Task<bool> AddAsync(OrderDetail orderDetail);
        Task<IEnumerable<OrderDetail>> GetAllAsync();
        Task<OrderDetail?> GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(OrderDetail orderDetail);
    }
}
