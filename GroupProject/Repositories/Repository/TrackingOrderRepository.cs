using ModelsV2.DAOs;
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
        public Task<bool> AddAsync(TrackingOrder trackingOrder)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TrackingOrder>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TrackingOrder?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TrackingOrder trackingOrder)
        {
            throw new NotImplementedException();
        }
    }
}
