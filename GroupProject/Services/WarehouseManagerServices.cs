using BusinessObjects.Models;
using DataAccessLayers.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class WarehouseManagerServices : IWarehouseManagerService
    {
        private readonly IWarehouseManagerRepository _warehouseManagerRepository;
        public WarehouseManagerServices(IWarehouseManagerRepository warehouseManagerRepository)
        {
            _warehouseManagerRepository = warehouseManagerRepository;
        }
        public Task<IEnumerable<WarehouseManager>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public WarehouseManager GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public WarehouseManager getWarehouseManagementByWarehouseID(int id)
        {
            throw new NotImplementedException();
        }

        public WarehouseManager Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool LoginWithRoleWarehouseManager(string email, string password)
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
