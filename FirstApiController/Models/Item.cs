using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApiController.Models
{
    public class Item
    {
        public int ID { get; set; }
        public static int NextID = 1;
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int ItemQuality { get; set; }

        public Item()
        {
            //default con
        }

        public Item(string name, string category, double price, int itemQuality)
        {
            //NextID helps to generate unique ids for all objects.
            ID = NextID++;
            Name = name;
            Category = category;
            Price = price;
            ItemQuality = itemQuality;
        }
    }
}
