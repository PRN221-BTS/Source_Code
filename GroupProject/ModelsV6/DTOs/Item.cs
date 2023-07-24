using ModelsV6.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsV6.DTOs
{
    public class Item
    {
        public Bird bird { get; set; } 

        public int Quantity { get; set; } = 1;


        public string certificateBird { get; set; } = " ";

        public string BirdCage { get; set; } ="";

        public string OtherItems { get; set; } = " ";

        public int price { get; set; } = 0;



    }
}
