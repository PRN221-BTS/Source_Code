using Model.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IShipperRepository
    {
        bool Register(Shipper shipper);
        bool Login(string email, string password);
        Task<bool> AddAsync(Shipper shipper);
        Task<IEnumerable<Shipper>> GetAllAsync();
        Task<Shipper?> GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(Shipper shipper);
    }
}
