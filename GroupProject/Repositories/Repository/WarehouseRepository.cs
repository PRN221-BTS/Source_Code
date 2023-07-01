using Model.DAOs;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repoository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private static BirdTransportationSystemContext  _context = new BirdTransportationSystemContext();
        public Task<bool> AddAsync(Warehouse customer)
        {
            throw new NotImplementedException();
        }

        public List<Warehouse> GetAllAsync()=> _context.Warehouses.ToList();    

        public Task<Warehouse?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Warehouse customer)
        {
            throw new NotImplementedException();
        }
    }
}
