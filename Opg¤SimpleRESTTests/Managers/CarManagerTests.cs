using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opg_SimpleREST.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryTests;

namespace Opg_SimpleREST.Managers.Tests
{
    [TestClass()]
    public class CarManagerTests
    {
        private CarManager _carManager;

        [TestInitialize]
        public void Setup()
        {
            _carManager = new CarManager();
        }

        [TestMethod()]
        public void TestGetAll()
        {

            Assert.AreEqual(_carManager.GetAll(45890000).Count, 3);

            Assert.IsTrue(_carManager.GetAll(0).Count == 0);

        }

        [TestMethod()]
        public void TestGetAllWithMaxPrice()
        {
            List<Car> cars = _carManager.GetAll(45890000);
            foreach (Car c in cars)
            {
                Assert.IsTrue(c.Price <= 45890000);
            }
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            //checking the first Item
            Assert.IsTrue(_carManager.GetByID(1).Model.Equals("Lamborghini"));
            //checking an ID that shouldn't exist
            Assert.IsNull(_carManager.GetByID(10));
        }

        [TestMethod()]
        public void AddCarTest()
        {
            int beforeAddCount = _carManager.GetAll(458910000).Count;
            int defaultID = 0;

            Car newCar = new Car("FiatT", 458910000, "5698k");

            Car addResult = _carManager.AddCar(newCar);
            int newID = addResult.ID;

            Assert.AreNotEqual(defaultID, newID);
            Assert.AreEqual(beforeAddCount + 1, _carManager.GetAll(458910000).Count);
        }

        [TestMethod()]
        public void DeleteCarTest()
        {
            int beforeAddCount = _carManager.GetAll(458910000).Count;

            Car newCar = new Car("SiaST", 458910000, "5698k");
            Car addResult = _carManager.AddCar(newCar);
            int newID = addResult.ID;

            Car deletedCar = _carManager.DeleteCar(newID);

            Assert.AreEqual(beforeAddCount, _carManager.GetAll(458910000).Count);
            Assert.IsNull(_carManager.DeleteCar(10));


        }
    }
}