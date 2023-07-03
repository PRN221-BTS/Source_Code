using ModelsV4.DAOs;
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
        Shipper Login(string email, string password);
        Task<bool> AddAsync(Shipper shipper);
        Task<IEnumerable<Shipper>> GetAllAsync();
        Task<Shipper?> GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(Shipper shipper);

        Warehouse  GetWarehouseById(int id);

        Shipper GetShipperById(int id);

        List<Shipper> GetShippersByWarehouseID(int WarehouseID);

        List<Shipper> GetShippersByWarehouseName(string WarehouseName);

        
    }
}
