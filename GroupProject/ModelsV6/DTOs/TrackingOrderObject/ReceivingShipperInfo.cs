﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsV6.DTOs.TrackingOrderObject
{
    public class ReceivingShipperInfo
    {
        public string ReceivingAddress { get; set; }
        public string ColorProperty { get; set; }
        public string  ShipperName { get; set; }

        public string ShipperEmail { get; set;}

        public string ShipperPhone { get; set;}

        public string ShipperVehicle { get; set;}

        public string RouteStatus { get; set; }


    }
}
