using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IWarehouseManagerService
    {
        Task<IEnumerable<WarehouseManager>> GetAllAsync();
        WarehouseManager GetByIdAsync(int id);
        WarehouseManager getWarehouseManagementByWarehouseID(int id);
        WarehouseManager Login(string email, string password);
        bool LoginWithRoleWarehouseManager(string email, string password);
        bool Remove(int id);
        bool Update(WarehouseManager customer);
    }
}
