using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers.Interfaces
{
    public interface IWarehouseManagerRepository
    {
        Task<bool> AddAsync(WarehouseManager warehouseManager);
        Task<IEnumerable<WarehouseManager>> GetAllAsync();
        WarehouseManager GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(WarehouseManager customer);

        WarehouseManager getWarehouseManagementByWarehouseID(int id);

        public bool LoginWithRoleWarehouseManager(string email,string password);
        WarehouseManager Login(string email, string password);
    }
}
