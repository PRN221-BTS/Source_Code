using Microsoft.EntityFrameworkCore;
using ModelsV6.DAOs;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repoository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private static BirdTransportationSystemContext  _context = new BirdTransportationSystemContext();
        public Task<bool> AddAsync(Warehouse customer)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddTrackingOrder(TrackingOrder order)
        {
          _context.TrackingOrders.Add(order);
        await    _context.SaveChangesAsync();
            return true;
        }

        public List<Warehouse> GetAllAsync()=> _context.Warehouses.Include(x =>x.Shippers).ToList();    

        public Warehouse? GetByIdAsync(int id) => _context.Warehouses.FirstOrDefault(x => x.WarehouseId == id);

        public int GetLastObjectInTrackingOrder()
        {

            int valueMax = _context.TrackingOrders.OrderByDescending(x => x.TrackingOrderId).FirstOrDefault()?.TrackingOrderId ?? 1;

            if(valueMax  == null)
            {
                valueMax = 1;
            }
            return (int)valueMax;
        }

        public Warehouse getWarehouseInfoByWarehouseManagerID(int id) => _context.Warehouses.FirstOrDefault(x => x.WarehouseManagerId == id);
    

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Warehouse customer)
        {
            throw new NotImplementedException();
        }

        //public List<Warehouse> listShipperWithWarehouse()
        //{
        //    List<Warehouse> warehouses = new List<Warehouse>();
        //    warehouses = _context.
        //    return warehouses;
        //}
    }
}
