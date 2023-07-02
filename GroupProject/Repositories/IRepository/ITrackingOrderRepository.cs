using ModelsV2.DAOs;
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
        Task<TrackingOrder?> GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(TrackingOrder trackingOrder);
    }
}
