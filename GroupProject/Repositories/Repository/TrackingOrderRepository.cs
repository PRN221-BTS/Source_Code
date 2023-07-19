using ModelsV6.DAOs;
using ModelsV6.DTOs.State;
using Repositories.HelperRepository.HandleViewFormat;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repoository
{
    public class TrackingOrderRepository : ITrackingOrderRepository
    {
        WarehouseTrackingFormat _trackingFormat;
        public TrackingOrderRepository(WarehouseTrackingFormat trackingFormat)
        {
            _trackingFormat = trackingFormat;
        }
        BirdTransportationSystemContext _context = new BirdTransportationSystemContext();
        public Task<bool> AddAsync(TrackingOrder trackingOrder)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TrackingOrder>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TrackingOrder GetByIdAsync(int id) => _context.TrackingOrders.FirstOrDefault(x => x.TrackingOrderId == id);
      

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TrackingOrder trackingOrder)
        {
            throw new NotImplementedException();
        }

       
      

        public bool UpdateInWarehouseStateInTrackingOrderWithDeliveryState(int trackingOrderId)
        {
            _context = new BirdTransportationSystemContext();
            TrackingOrder trackingOrder = GetByIdAsync(trackingOrderId);
            OrderInRoute orderInRoute = _trackingFormat.getOrderInRouteByTrackingOrderID(trackingOrderId,RouteState.Receiving.ToString(),OrderInRouteState.Coming.ToString());
            orderInRoute.Status = OrderInRouteState.Done.ToString();
            trackingOrder.TrackingStatus = TrackingState.InWarehouse.ToString();
            _context.OrderInRoutes.Update(orderInRoute);
            _context.TrackingOrders.Update(trackingOrder);
            _context.SaveChanges();
            return true;

            

        }

        public bool UpdateShippedStateInTrackingOrderToInWarehouseState(int trackingOrderId)
        {
            _context = new BirdTransportationSystemContext();
            TrackingOrder trackingOrder = GetByIdAsync(trackingOrderId);
            trackingOrder.TrackingStatus = TrackingState.InWarehouse.ToString();
            _context.TrackingOrders.Update(trackingOrder);
            _context.SaveChanges();
            return true;

        }


        public bool UpdateSuccessStateInOrderInBatch(int trackingOrderId)
        {
            throw new NotImplementedException();
        }

        public TrackingOrder getNextTrackingOrder(TrackingOrder trackingOrder) => _context.TrackingOrders.FirstOrDefault(x => x.SequenceNumber == trackingOrder.SequenceNumber + 1 && x.OrderId == trackingOrder.OrderId);

        public bool UpdateComingStateInTrackingOrder(int trackingOrderId)
        {
            _context = new BirdTransportationSystemContext();
            TrackingOrder trackingOrder = GetByIdAsync(trackingOrderId);
            trackingOrder.TrackingStatus = TrackingState.Shipped.ToString();
            _context.TrackingOrders.Update(trackingOrder);
            TrackingOrder nextTrackingOrder = getNextTrackingOrder(GetByIdAsync(trackingOrderId));
            nextTrackingOrder.TrackingStatus = TrackingState.Coming.ToString();
            _context.TrackingOrders.Update(nextTrackingOrder);
            _context.SaveChanges(); 
            return true;

        }


        public bool SendOrderToCustomer(int trackingOrderId)
        {
            _context = new BirdTransportationSystemContext();
            TrackingOrder trackingOrder = GetByIdAsync(trackingOrderId);
            trackingOrder.TrackingStatus = TrackingState.Shipped.ToString();
            _context.TrackingOrders.Update(trackingOrder);
            OrderInRoute orderInRoute = _trackingFormat.getOrderInRouteByTrackingOrderID(trackingOrderId,RouteState.Sending.ToString(),OrderInRouteState.Pending.ToString()); 
            orderInRoute.Status = OrderInRouteState.Coming.ToString();
            _context.OrderInRoutes.Update(orderInRoute);
            _context.SaveChanges();
            return true;
           
        }
    }
}
