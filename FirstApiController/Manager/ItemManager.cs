using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using FirstApiController.Models;

namespace FirstApiController.Manager
{
    public class ItemManager
    {
        //NextID helps the manager generate unique ids for all objects.
        private static int _nextID = 1;

        private static List<Item> _data = new List<Item>()
        {
            new Item() {ID = _nextID++, Name = "Batman Lego", Category = "Lego", Price = 599, ItemQuality = 7},
            new Item() {ID = _nextID++, Name = "Computer Network", Category = "Book", Price = 450, ItemQuality = 6},
            new Item() {ID = _nextID++, Name = "Cups", Category = "Bodum", Price = 300, ItemQuality = 8},
        };

        public List<Item> GetAll()
        {
            List<Item> result = new List<Item>(_data);

            result = _data.FindAll(i => i.Name.Equals(StringComparison.OrdinalIgnoreCase));
            return result;
        }

        public Item GetByID(int id)
        {
            return _data.Find(i =>i.ID == id);

            //foreach (Item item in data)
            //{
            //    if (item.ID == id)
            //    {
            //        return item;
            //    }
            //}
        }

        public Item Add(Item item)
        {
             _data.Add(item);
             return item;
        }

        public Item Update(int id, Item updateItem)
        {
            var item = GetByID(id);

            if (item == null)
            {
                return null;
            }
            item.Name = updateItem.Name;
            item.Category = updateItem.Category;
            item.ItemQuality = updateItem.ItemQuality;
            item.Price = updateItem.Price;
            return item;
        }

        public Item Delete(int id)
        {
            var item = GetByID(id);

            if (item == null)
            {
                return null;
            }

            _data.Remove(item);
            return item;
        }
    }
}
