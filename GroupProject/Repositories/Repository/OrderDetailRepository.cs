using Model.DAOs;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repoository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public Task<bool> AddAsync(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
