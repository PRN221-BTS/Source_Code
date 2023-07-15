using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsV6.DTOs.TrackingOrderObject
{
    public class WarehouseTrackingInfo
    {
        public int SequenceNumber { get; set; }
        public string ColorProperty { get; set; } 
        public string TrackingOrder { get; set; }
        public string WarehouseName { get; set; }

        public string WarhouseLocation { get; set; }

        public string WarehouseStatus { get; set; }

    }
}
