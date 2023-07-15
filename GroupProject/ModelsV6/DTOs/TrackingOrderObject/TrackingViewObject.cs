using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsV6.DTOs.TrackingOrderObject
{
    public class TrackingViewObject
    {

        public ReceivingShipperInfo receivingShipperInfo { get; set; }

        public SendingShipperInfo sendingShipperInfo { get; set; }

        public List<WarehouseTrackingInfo> warehouseTrackingInfo { get; set; }
    }
}
