using System;
using System.Collections.Generic;

namespace RESTClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HTTP Client!");

            HTTPWorker myWorker = new HTTPWorker();

            Book book = new Book() { ID = 1, Title = "dhdh", Price = 559 };
            Book returnBook = myWorker.PostBook(book).Result;

            Console.WriteLine("My bog ID: " + returnBook.ID);
            Console.WriteLine();

            IEnumerable<Book> allBooks = myWorker.GetAllBooks().Result;

            foreach (Book myBook in allBooks)
            {
                Console.WriteLine("Book title:" + myBook.Title);
            }
        }
    }
}
