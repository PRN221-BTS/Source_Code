using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers.Interfaces
{
    public interface IRouteRepository
    {
        Task<bool> AddAsync(Payment payment);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(Payment payment);
        Task<bool> AddNewRoute(Route route);

        public int GetLastValueObject();

        public bool UpdateRouteStatusToDoneById(int id);
    }
}
