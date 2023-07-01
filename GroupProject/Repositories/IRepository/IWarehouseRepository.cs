using Model.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IWarehouseRepository
    {
        Task<bool> AddAsync(Warehouse customer);
        List<Warehouse> GetAllAsync();
        Task<Warehouse?> GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(Warehouse customer);
    }
}
