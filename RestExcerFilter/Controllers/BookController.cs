using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excer1.Managers;
using Excer1.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Excer1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
       
        private BooksManager _manager = new BooksManager();

        private readonly IMemoryCache _memoryCache;

        private static readonly string _bookCache = "books";
        /// <summary>
        /// Cache
        /// </summary>
        /// <param name="memoryCache"></param>
        
        public BookController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// This means that you can ask the controller for an object
        /// with the specified id
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="minimumPrice"></param>
        /// <returns>
        /// <response code="404">its not found</response>
        /// <response code="200">Everything is ok?</response>
        /// </returns>

        // GET api/Book? filter=<value>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get([FromQuery] string filter, [FromQuery] int? minimumPrice, [FromHeader] int bookAmount)
        {
            IEnumerable<Book> books = null;

            //if (_memoryCache.TryGetValue(BookCache, out books))
            //{
            //    return books;
            //}

            books = _manager.GetAll(filter, minimumPrice);

            //var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30));
            //_memoryCache.Set(BookCache, books, cacheOptions);

            if (books.Count() <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(books.Take(bookAmount));
            }
        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _manager.GetByID(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public Book Post([FromBody] Book newBook)
        {
            return _manager.AddBook(newBook);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public Book Put(int id, [FromBody] Book updateBook)
        {
            return _manager.UpdateBook(id, updateBook);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public Book Delete(int id)
        {
            return _manager.DeleteBook(id);
        }
    }
}
