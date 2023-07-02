using ModelsV2.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IWarehouseManagerRepository
    {
        Task<bool> AddAsync(WarehouseManager warehouseManager);
        Task<IEnumerable<WarehouseManager>> GetAllAsync();
        Task<WarehouseManager?> GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(WarehouseManager customer);

        WarehouseManager getWarehouseManagementByWarehouseID(int id);

    }
}
