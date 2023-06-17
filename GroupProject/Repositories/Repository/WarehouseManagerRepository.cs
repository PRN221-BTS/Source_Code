using Model.DAOs;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repoository
{
    public class WarehouseManagerRepository : IWarehouseManagerRepository
    {
        public Task<bool> AddAsync(WarehouseManager customer)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WarehouseManager>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WarehouseManager?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(WarehouseManager customer)
        {
            throw new NotImplementedException();
        }
    }
}
