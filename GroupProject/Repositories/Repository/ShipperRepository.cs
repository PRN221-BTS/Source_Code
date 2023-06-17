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

        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }

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
