using ModelsV5.DAOs;
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

        public bool AddNewRoute(Route route)
        {
            _context.Routes.Add(route);
            _context.SaveChanges();
            return true;
        }


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
    }
}
