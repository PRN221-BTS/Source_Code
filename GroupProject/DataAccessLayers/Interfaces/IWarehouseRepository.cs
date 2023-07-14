using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<bool> AddAsync(Warehouse customer);
        List<Warehouse> GetAllAsync();
        public Warehouse? GetByIdAsync(int id);
        bool Remove(int id);
        bool Update(Warehouse customer);

        int GetLastObjectInTrackingOrder();

        Task<bool> AddTrackingOrder(TrackingOrder order);

        Warehouse getWarehouseInfoByWarehouseManagerID(int id);

        
    }
}
