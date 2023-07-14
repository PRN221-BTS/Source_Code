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
    public class BirdServices : IBirdServices
    {
        private readonly IBirdRepository _birdRepository;
        public BirdServices(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }
        public bool AddAsync(Bird bird)
        {
            throw new NotImplementedException();
        }

        public Bird FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Bird> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public List<Bird> GetByCustomerID(int CustomerID)
        {
            throw new NotImplementedException();
        }

        public Bird? GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int GetLastID()
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
