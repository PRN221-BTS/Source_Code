using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsV5.DTOs
{
    public enum TrackingState
    {
        //using for the warehouse have sequence number = 1 and transfer in route
        Delivery,
        // using for another sequence number
        InRoute,
        //using state with the order in warehousee
        InWarehouse,
        UnProcessing,
        Pending,
        Canceling,
//đã chuyển qua kho khác
        Shipped,
        Coming,
        Processing

        


    }
}
