using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsV5.DTOs
{
    public class OrderInWarehouse
    {
        public int OrderId { get; set; } 

        public string sendingAddress { get; set; }   

        public string receivingAddress { get; set; }

        public int  sequenceNumber { get; set; }

        public string Note { get; set; }
        public string TrackingStatus { get; set; }
        public int TrackingOrderId { get; set; }
     
    }
}
