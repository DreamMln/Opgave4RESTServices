using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientItems
{
    public class HTTPWorker
    {
        private string _itemUrl = "http://localhost:36926/api/book";

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            IEnumerable<Item> allItems = null;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_itemUrl);

                allItems = await response.Content.ReadFromJsonAsync<IEnumerable<Item>>();

            }
            return allItems;
        }
    }
}
