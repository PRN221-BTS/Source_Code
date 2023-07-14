using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRouteServices
    {
        Task<bool> AddAsync(Payment payment);
        Task<bool> AddNewRoute(Route route);
        OrderInRoute GetOrderInRouteById(int id);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(Payment payment);
        int GetLastValueObject();
        bool UpdateRouteStatusToDoneById(int id);
    }
}
