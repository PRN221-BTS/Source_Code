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
    public class WarehouseServices : IWarehouseServices
    {
        private readonly IWarehouseRepository _repository;
        public WarehouseServices(IWarehouseRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> AddAsync(Warehouse customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddTrackingOrder(TrackingOrder order)
        {
            throw new NotImplementedException();
        }

        public List<Warehouse> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Warehouse? GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int GetLastObjectInTrackingOrder()
        {
            throw new NotImplementedException();
        }

        public Warehouse getWarehouseInfoByWarehouseManagerID(int id)
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
