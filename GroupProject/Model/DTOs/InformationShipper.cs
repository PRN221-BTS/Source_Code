using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class InformationShipper
    {
        public string ShipperName { get; set; }

        public string ShipperEmail { get; set; }

        public string ShipperPhoneNumber { get; set; }

        public string VehicleType { get; set; } 

        public string WarehouseName { get; set;}

        public string WarehouseLocation { get; set;}
    }
}
