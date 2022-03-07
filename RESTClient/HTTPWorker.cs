using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RESTClient
{
    public class HTTPWorker
    {
        private string BookUrl = "http://localhost:36926/api/book";
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            IEnumerable<Book> allBooks = null;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(BookUrl);
                    
                allBooks = await response.Content.ReadFromJsonAsync<IEnumerable<Book>>();

            }
            return allBooks;
        }

        public async Task<Book> PostBook(Book newBook)
        {
            using (HttpClient client = new HttpClient())
            {
                JsonContent serializeItem = JsonContent.Create(newBook);
                HttpResponseMessage response = await client.PostAsync(BookUrl, serializeItem);
                return await response.Content.ReadFromJsonAsync<Book>();
            }
        }

        public async Task<Book> Put(int id, Book updateBook)
        {
            using (HttpClient client = new HttpClient())
            {
                JsonContent serializeItem = JsonContent.Create( updateBook);

                HttpResponseMessage response = await client.PutAsync($"/" + id, serializeItem);
                return await response.Content.ReadFromJsonAsync<Book>();
            }

               
        }
        public async Task<Book> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"/" + id);
                return await response.Content.ReadFromJsonAsync<Book>();
            }
        }


    }
}
