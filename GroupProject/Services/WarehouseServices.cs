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

        public Task<bool> AddAsync(Warehouse customer) => _repository.AddAsync(customer);

        public Task<bool> AddTrackingOrder(TrackingOrder order) => _repository.AddTrackingOrder(order);

        public List<Warehouse> GetAllAsync() => _repository.GetAllAsync();

        public Warehouse? GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public int GetLastObjectInTrackingOrder() => _repository.GetLastObjectInTrackingOrder();

        public Warehouse getWarehouseInfoByWarehouseManagerID(int id) => _repository.getWarehouseInfoByWarehouseManagerID(id);

        public bool Remove(int id) => _repository.Remove(id);

        public bool Update(Warehouse customer) => _repository.Update(customer);
    }
}
