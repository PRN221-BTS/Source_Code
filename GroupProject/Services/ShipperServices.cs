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
        public Task<bool> AddAsync(Shipper shipper) => _shipperRepository.AddAsync(shipper);

        public Task<IEnumerable<Shipper>> GetAllAsync() => _shipperRepository.GetAllAsync();

        public Task<Shipper?> GetByIdAsync(int id) => _shipperRepository.GetByIdAsync(id);

        public Shipper GetShipperById(int id) => _shipperRepository.GetShipperById(id);

        public List<Shipper> GetShippersByWarehouseID(int WarehouseID) => _shipperRepository.GetShippersByWarehouseID(WarehouseID);

        public List<Shipper> GetShippersByWarehouseName(string WarehouseName) => _shipperRepository.GetShippersByWarehouseName(WarehouseName);

        public Warehouse GetWarehouseById(int id) => _shipperRepository.GetWarehouseById(id);

        public Shipper Login(string email, string password) => _shipperRepository.Login(email, password);

        public bool Register(Shipper shipper) => _shipperRepository.Register(shipper);

        public bool Remove(int id) => _shipperRepository.Remove(id);

        public bool Update(Shipper shipper) => _shipperRepository.Update(shipper);
    }
}
