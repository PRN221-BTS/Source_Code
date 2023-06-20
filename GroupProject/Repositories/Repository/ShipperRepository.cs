using Model.DAOs;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repoository
{
    public class ShipperRepository : IShipperRepository
    {

        private static BirdTransportationSystemContext _context = new BirdTransportationSystemContext();
        public Task<bool> AddAsync(Shipper shipper)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shipper>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Shipper?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Shipper Login(string email, string password) => _context.Shippers.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
       

        public bool Register(Shipper shipper)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shipper shipper)
        {
            throw new NotImplementedException();
        }
    }
}
