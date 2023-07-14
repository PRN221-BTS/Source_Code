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
    public class ShipperServices : IShipperServices
    {
        private readonly IShipperRepository _shipperRepository;
        public ShipperServices(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }
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

        public Shipper GetShipperById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Shipper> GetShippersByWarehouseID(int WarehouseID)
        {
            throw new NotImplementedException();
        }

        public List<Shipper> GetShippersByWarehouseName(string WarehouseName)
        {
            throw new NotImplementedException();
        }

        public Warehouse GetWarehouseById(int id)
        {
            throw new NotImplementedException();
        }

        public Shipper Login(string email, string password)
        {
            throw new NotImplementedException();
        }

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
