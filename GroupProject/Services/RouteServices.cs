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
        public Task<bool> AddAsync(Payment payment) => _routeRepository.AddAsync(payment);

        public Task<bool> AddNewRoute(Route route) => _routeRepository.AddNewRoute(route);

        public Task<IEnumerable<Payment>> GetAllAsync() => _routeRepository.GetAllAsync();

        public Task<Payment?> GetByIdAsync(int id) => _routeRepository.GetByIdAsync(id);

        public int GetLastValueObject() => _routeRepository.GetLastValueObject();

        public OrderInRoute GetOrderInRouteById(int id) => _routeRepository.GetOrderInRouteById(id);

        public bool Remove(int id) => _routeRepository.Remove(id);

        public bool Update(Payment payment) => _routeRepository.Update(payment);

        public bool UpdateRouteStatusToDoneById(int id) => _routeRepository.UpdateRouteStatusToDoneById(id);
    }
}
