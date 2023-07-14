using BusinessObjects.Models;
using DataAccessLayers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers.Repositories
{
    public class ShipperRepository : IShipperRepository
    {

        private static BirdTransportationSystemContext _context = new BirdTransportationSystemContext();
        public Task<bool> AddAsync(Shipper shipper)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shipper>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Shipper?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Shipper GetShipperById(int id) => _context.Shippers.FirstOrDefault(x => x.ShipperId == id);

        public List<Shipper> GetShippersByWarehouseID(int WarehouseID) => _context.Shippers.Where(x => x.WarehouseId == WarehouseID).ToList();

        public List<Shipper> GetShippersByWarehouseName(string WarehouseName)
        {
            throw new NotImplementedException();
        }

        public Warehouse GetWarehouseById(int id) => _context.Warehouses.FirstOrDefault(x => x.WarehouseId == id);
        

        public Shipper Login(string email, string password) => _context.Shippers.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
       

        public bool Register(Shipper shipper)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shipper shipper)
        {
            throw new NotImplementedException();
        }

    }
}
