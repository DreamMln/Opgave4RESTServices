using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excer1.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excer1.Managers.Tests
{
    [TestClass()]
    public class BooksManagerTests
    {
        //ref - instance field
        private BooksManager _manager;

        public BooksManagerTests()
        {
            _manager = new BooksManager();
        }

        public void GetAllTest()
        {
            //Assert
            Assert.IsNotNull(_manager.GetAll(null, null));

            int expected = 1;

            //are equal to
            Assert.AreEqual(expected, _manager.GetAll(null, 400).Count());
            
            //are not equal to
            Assert.AreNotEqual(expected, _manager.GetAll(null, 401).Count());
        }

        [TestMethod()]
        public void GetByIDTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void AddBookTest()
        {
           // Assert.Fail();
        }

        [TestMethod()]
        public void UpdateBookTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void DeleteBookTest()
        {
            //Assert.Fail();
        }
    }
}