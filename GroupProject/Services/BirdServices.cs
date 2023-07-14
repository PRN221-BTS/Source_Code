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
        public bool AddAsync(Bird bird) => _birdRepository.AddAsync(bird);

        public Bird FindById(int id) => _birdRepository.FindById(id);

        public List<Bird> GetAllAsync() => _birdRepository.GetAllAsync();

        public List<Bird> GetByCustomerID(int CustomerID) => _birdRepository.GetByCustomerID(CustomerID);

        public Bird? GetByIdAsync(int id) => _birdRepository?.GetByIdAsync(id);

        public int GetLastID() => _birdRepository.GetLastID();

        public bool Remove(int id) => _birdRepository.Remove(id);

        public bool Update(Bird bird) => _birdRepository.Update(bird);
    }
}
