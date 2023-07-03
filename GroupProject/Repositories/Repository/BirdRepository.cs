using ModelsV4.DAOs;
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

        public bool AddAsync(Bird bird)
        {
            _transportationSystemContext.Add(bird);
            _transportationSystemContext.SaveChanges();
            return true;
        }

        public Bird FindById(int id) => _transportationSystemContext.Birds.FirstOrDefault(x => x.BirdId == id);

        public List<Bird> GetAllAsync() => _transportationSystemContext.Birds.ToList();
     

        public List<Bird> GetByCustomerID(int CustomerID) => _transportationSystemContext.Birds.Where(x => x.CustomerId == CustomerID).ToList();
  

        public Bird? GetByIdAsync(int id) => _transportationSystemContext.Birds.FirstOrDefault( x=> x.BirdId.Equals(id));

        public int GetLastID() => _transportationSystemContext.Birds.OrderByDescending( x => x.BirdId).FirstOrDefault().BirdId;
      

        public bool Remove(int id)
        {
            _transportationSystemContext.Remove(FindById(id));
            _transportationSystemContext.SaveChanges();
            return true;
        }

        public bool Update(Bird bird)
        {
            _transportationSystemContext = new BirdTransportationSystemContext();
            _transportationSystemContext.Update(bird);
            return true;
        }
    }
}
