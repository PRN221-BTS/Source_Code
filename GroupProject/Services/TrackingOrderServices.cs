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
        public Task<bool> AddAsync(TrackingOrder trackingOrder)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TrackingOrder>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TrackingOrder GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public TrackingOrder getNextTrackingOrder(TrackingOrder trackingOrder)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool SendOrderToCustomer(int trackingOrderId)
        {
            throw new NotImplementedException();
        }

        public bool Update(TrackingOrder trackingOrder)
        {
            throw new NotImplementedException();
        }

        public bool UpdateComingStateInTrackingOrder(int trackingOrderId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInWarehouseStateInTrackingOrderWithDeliveryState(int trackingOrderId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateShippedStateInTrackingOrderToInWarehouseState(int trackingOrderId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSuccessStateInOrderInBatch(int trackingOrderId)
        {
            throw new NotImplementedException();
        }
    }
}
