using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITrackingOrderServices
    {
        Task<bool> AddAsync(TrackingOrder trackingOrder);
        Task<IEnumerable<TrackingOrder>> GetAllAsync();
        TrackingOrder GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(TrackingOrder trackingOrder);
        bool UpdateInWarehouseStateInTrackingOrderWithDeliveryState(int trackingOrderId);
        bool UpdateShippedStateInTrackingOrderToInWarehouseState(int trackingOrderId);
        bool UpdateSuccessStateInOrderInBatch(int trackingOrderId);
        TrackingOrder getNextTrackingOrder(TrackingOrder trackingOrder);
        bool UpdateComingStateInTrackingOrder(int trackingOrderId);
        bool SendOrderToCustomer(int trackingOrderId);
    }
}
