using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsV5.DTOs
{
    public class SendingOrder
    {
        public int RouteID { get; set; }
        public int OrderInRoutes { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public decimal Distance { get; set; }

        public string SendingAddress { get; set; }

        public string Note { get; set; }    
        public string RouteType { get; set; }
    }
}
