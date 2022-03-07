using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excer1.Models;
using Microsoft.AspNetCore.Cors;

namespace Excer1.Managers
{
    public class BooksManager
    {
        private static int _nextID = 1;
        private static List<Book> data = new List<Book>()
        {
            new Book() {ID = _nextID++, Title = "Computer Network", Price = 800},
            new Book() {ID = _nextID++, Title = "Not Computer Network", Price = 1000},
            new Book() {ID = _nextID++, Title = "Other Computer Networks", Price = 900}
        };

        //Change this function to look at the substring parameter, and if
        //not null/empty then filter the list you’re returning. 
        //? betyder at hvis vi gerne vil have den skal være null, hvis den ikke er udfyldt
        public List<Book> GetAll(string filter, int? minimumPrice)
        {
            List<Book> result = new List<Book>(data);
            if (!string.IsNullOrWhiteSpace(filter))
            {
                //case-insensitive
                result = data.FindAll(c => c.Title.Contains(filter, StringComparison.OrdinalIgnoreCase));
            }
            //else
            //{
            //    result = new List<Book>(data);
            //}

            //udvider: tjekker hvis ikke null, så filtrer min price
            if (minimumPrice != null)
            {
                result = result.FindAll(c => c.Price >= minimumPrice);
            }
            return result;
        }

        public Book GetByID(int ID)
        {
            return data.Find(book => book.ID == ID);

            //foreach (Book book in data)
            //{
            //    if (book.ID == ID)
            //    {
            //        return book;
            //    }
            //}
        }

        //CORS Policies
        //[DisableCors]
        [EnableCors("allowAllPolicies")]
        public Book AddBook(Book newBook)
        {
            newBook.ID = _nextID++;
            data.Add(newBook);
            //returnere den nye bog
            return newBook;
        }

        //CORS
        [EnableCors("allowAllPolicies")]
        public Book UpdateBook(int id, Book updateBook)
        {
            var book = GetByID(id);

            if (book == null)
            {
                return null;
            }
            book.Title = updateBook.Title;
            book.Price = updateBook.Price;
            return book;
        }

        public Book DeleteBook(int id)
        {
            var book = GetByID(id);

            if (book == null)
            {
                return null;
            }

            data.Remove(book);
            return book;
        }
    }
}
