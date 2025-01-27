﻿using ModelsV6.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface ITrackingOrderRepository
    {
        Task<bool> AddAsync(TrackingOrder trackingOrder);
        Task<IEnumerable<TrackingOrder>> GetAllAsync();
        public TrackingOrder GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(TrackingOrder trackingOrder);

         bool UpdateSuccessStateInOrderInBatch(int trackingOrderId);

        bool UpdateInWarehouseStateInTrackingOrderWithDeliveryState(int trackingOrderId);

        bool UpdateComingStateInTrackingOrder(int trackingOrderId);

         bool UpdateShippedStateInTrackingOrderToInWarehouseState(int trackingOrderId);

         bool SendOrderToCustomer(int trackingOrderId);
    }
}
