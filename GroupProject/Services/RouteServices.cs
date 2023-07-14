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
    public class RouteServices : IRouteServices
    {
        private readonly IRouteRepository _routeRepository;
        public RouteServices(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }
        public Task<bool> AddAsync(Payment payment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddNewRoute(Route route)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Payment?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int GetLastValueObject()
        {
            throw new NotImplementedException();
        }

        public OrderInRoute GetOrderInRouteById(int id)
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

        public bool UpdateRouteStatusToDoneById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
