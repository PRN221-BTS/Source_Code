using ModelsV5.DAOs;
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
        private static BirdTransportationSystemContext _context = new BirdTransportationSystemContext();
        public async Task<bool> AddAsync(WarehouseManager warehouseManager)
        {
            await _context.WarehouseManagers.AddAsync(warehouseManager);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<WarehouseManager>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public WarehouseManager GetByIdAsync(int id) => _context.WarehouseManagers.FirstOrDefault(x => x.WarehouseManagerId == id);
  

        public WarehouseManager getWarehouseManagementByWarehouseID(int id) => _context.WarehouseManagers.FirstOrDefault(x => x.WarehouseManagerId == id);

        public WarehouseManager Login(string email, string password) => _context.WarehouseManagers.Where(x => x.Email == email && x.Password == password).FirstOrDefault();

        public bool LoginWithRoleWarehouseManager(string email, string password) => _context.WarehouseManagers.Where(x =>x.Email == email && x.Password == password).Any(); 
     

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
