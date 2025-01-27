﻿using ModelsV6.DAOs;
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
            _transportationSystemContext.Birds.Remove(FindById(id));
            _transportationSystemContext.SaveChanges();
            return true;
        }

        public bool Update(Bird bird)
        {
            _transportationSystemContext = new BirdTransportationSystemContext();
            _transportationSystemContext.Birds.Update(bird);
            _transportationSystemContext.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateQuantity(int birdID)
        {
          
            var birdFinding = GetByIdAsync(birdID);
            if (birdFinding != null)
            {
                _transportationSystemContext = new BirdTransportationSystemContext();
                birdFinding.BirdQuantity -= 1;
                _transportationSystemContext.Birds.Update(birdFinding);
                 await _transportationSystemContext.SaveChangesAsync();
                return true;
            }

            return false;
        }


        public bool CheckValidationBird(string birdName,int customerID) => !_transportationSystemContext.Birds.Any(x => x.BirdName == birdName && x.CustomerId == customerID);
    }
}
