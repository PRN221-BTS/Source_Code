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
        public Task<IEnumerable<WarehouseManager>> GetAllAsync() => _warehouseManagerRepository.GetAllAsync();

        public WarehouseManager GetByIdAsync(int id) => _warehouseManagerRepository.GetByIdAsync(id);

        public WarehouseManager getWarehouseManagementByWarehouseID(int id) => _warehouseManagerRepository.getWarehouseManagementByWarehouseID(id);

        public WarehouseManager Login(string email, string password) => _warehouseManagerRepository.Login(email, password);

        public bool LoginWithRoleWarehouseManager(string email, string password) => _warehouseManagerRepository.LoginWithRoleWarehouseManager(email, password);

        public bool Remove(int id) => _warehouseManagerRepository.Remove(id);

        public bool Update(WarehouseManager customer) => _warehouseManagerRepository.Update(customer);
    }
}
