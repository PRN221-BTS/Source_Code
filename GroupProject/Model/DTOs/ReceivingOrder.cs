using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class ReceivingOrder
    {
        public int RouteID { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public decimal Distance { get; set; }

        public string ReceivingAddress { get; set; }

        public string Note { get; set; }
    }
}
