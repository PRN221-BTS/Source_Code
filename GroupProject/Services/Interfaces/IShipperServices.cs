using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IShipperServices
    {
        Task<bool> AddAsync(Shipper shipper);
        Task<IEnumerable<Shipper>> GetAllAsync();
        Task<Shipper?> GetByIdAsync(int id);
        Shipper GetShipperById(int id);
        List<Shipper> GetShippersByWarehouseID(int WarehouseID);
        List<Shipper> GetShippersByWarehouseName(string WarehouseName);
        Warehouse GetWarehouseById(int id);
        Shipper Login(string email, string password);
        bool Register(Shipper shipper);
        bool Remove(int id);
        bool Update(Shipper shipper);
    }
}
