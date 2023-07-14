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
    public class TrackingOrderServices : ITrackingOrderServices
    {
        private readonly ITrackingOrderRepository _repository;
        public TrackingOrderServices(ITrackingOrderRepository repository)
        {
            _repository = repository;
        }
        public Task<bool> AddAsync(TrackingOrder trackingOrder) => _repository.AddAsync(trackingOrder);

        public Task<IEnumerable<TrackingOrder>> GetAllAsync() => _repository.GetAllAsync();

        public TrackingOrder GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public TrackingOrder getNextTrackingOrder(TrackingOrder trackingOrder) => _repository.getNextTrackingOrder(trackingOrder);

        public bool Remove(int id) => _repository.Remove(id);

        public bool SendOrderToCustomer(int trackingOrderId) => _repository.SendOrderToCustomer(trackingOrderId);

        public bool Update(TrackingOrder trackingOrder) => _repository.Update(trackingOrder);

        public bool UpdateComingStateInTrackingOrder(int trackingOrderId) => _repository.UpdateComingStateInTrackingOrder(trackingOrderId);

        public bool UpdateInWarehouseStateInTrackingOrderWithDeliveryState(int trackingOrderId) => _repository.UpdateInWarehouseStateInTrackingOrderWithDeliveryState(trackingOrderId);

        public bool UpdateShippedStateInTrackingOrderToInWarehouseState(int trackingOrderId) => _repository.UpdateShippedStateInTrackingOrderToInWarehouseState(trackingOrderId);

        public bool UpdateSuccessStateInOrderInBatch(int trackingOrderId) => _repository.UpdateSuccessStateInOrderInBatch(trackingOrderId);
    }
}
