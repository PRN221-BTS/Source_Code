using ModelsV2.DAOs;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repoository
{
    public class BirdRepository : IBirdRepository
    {
        BirdTransportationSystemContext _transportationSystemContext = new BirdTransportationSystemContext();
        public Task<bool> AddAsync(Bird bird)
        {
            throw new NotImplementedException();
        }

        public Bird FindById(int id) => _transportationSystemContext.Birds.FirstOrDefault(x => x.BirdId == id);
        

        public Task<IEnumerable<Bird>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Bird?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Bird bird)
        {
            throw new NotImplementedException();
        }
    }
}
