using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IWarehouseServices
    {
        Task<bool> AddAsync(Warehouse customer);
        Task<bool> AddTrackingOrder(TrackingOrder order);
        List<Warehouse> GetAllAsync();
        Warehouse? GetByIdAsync(int id);
        int GetLastObjectInTrackingOrder();
        Warehouse getWarehouseInfoByWarehouseManagerID(int id);
        bool Remove(int id);
        bool Update(Warehouse customer);
    }
}
