using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excer1.Models
{
    public class Book
    {
        /// <summary>
        /// add an ID, Title and Price to the book
        /// </summary>
        public int ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
    }
}
