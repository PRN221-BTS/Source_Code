using Microsoft.EntityFrameworkCore;
using ModelsV5.DAOs;
using ModelsV5.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.HandleViewFormat
{
    public class ShipperViewFormat
    {
        private static BirdTransportationSystemContext _context;

        public ShipperViewFormat(BirdTransportationSystemContext context)
        {
            _context = context;
        }

        public InformationShipper GetInformationShippers(int id)
        {
            var result = _context.Shippers.Include(x => x.Warehouse)
                .Where(x => x.ShipperId == id)
                .Select(x => new InformationShipper
                {
                    ShipperEmail = x.Email,
                    ShipperName = x.ShipperName,
                    ShipperPhoneNumber = x.PhoneNumber,
                    VehicleType = x.VehicleType,
                    WarehouseLocation = x.Warehouse.Location,
                    WarehouseName = x.Warehouse.WarehouseName
                }).FirstOrDefault();
            return result;
        }

       
    }
}
