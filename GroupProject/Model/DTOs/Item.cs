using Model.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class Item
    {
        public Bird bird { get; set; }

        public int Quantity { get; set; }
    }
}
