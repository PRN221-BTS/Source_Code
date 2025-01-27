﻿using ModelsV6.DAOs;
using ModelsV6.DTOs.State;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repoository
{
    public class RouteRepository : IRouteRepository
    {
     
        private static BirdTransportationSystemContext _context = new BirdTransportationSystemContext();
        public Task<bool> AddAsync(Payment payment)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddNewRoute(Route route)
        {
            _context.Routes.Add(route);
             await _context.SaveChangesAsync();
            return true;
        }
        public OrderInRoute GetOrderInRouteById(int id) => _context.OrderInRoutes.FirstOrDefault(x => x.OrderInRouteId == id);

        public Task<IEnumerable<Payment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Payment?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Payment payment)
        {
            throw new NotImplementedException();
        }

        public int GetLastValueObject() => _context.Routes.OrderByDescending(x => x.RouteId).FirstOrDefault().RouteId +1 ;

        public bool UpdateRouteStatusToDoneById(int id)
        {
            _context = new BirdTransportationSystemContext();
           OrderInRoute orderInRoute = _context.OrderInRoutes.FirstOrDefault(orderInRoute => orderInRoute.OrderInRouteId == id);
            orderInRoute.Status = OrderInRouteState.Done.ToString() ;
            _context.OrderInRoutes.Update(orderInRoute);
            _context.SaveChanges();
            return true;

        }
    }
}
