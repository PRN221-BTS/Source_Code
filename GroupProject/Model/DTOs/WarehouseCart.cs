using Model.DAOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class WarehouseCart
    {

      
        public int  SequenceNumber { get; set; }

        public int WarehouseID { get; set; }

        public string WarehouseName { get; set; }

        public string WarehouseLocation { get; set; }



   
    }
}
