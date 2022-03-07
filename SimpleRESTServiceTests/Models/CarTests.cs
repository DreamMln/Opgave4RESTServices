using ClassLibraryTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleRESTService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRESTService.Models.Tests
{

    [TestClass()]
    public class CarTests
    {
        //instance field
        private Car _car;

        //[TestInitialize]
        //public void Setup()
        //{
        //    Car car = new Car() { "Citroen", 5000, "pl48p"  };
        //}

        [TestMethod()]
        public void ValidCarTest()
        {
            //Arrange
            string expectedModel = "Citroën";
            int expectedPrice = 5000;
            string expectedLicensePlate = "4kl37";

            //Act 
            Car car = new Car(expectedModel, expectedPrice, expectedLicensePlate);

            //Assert
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedPrice, car.Price);
            Assert.AreEqual(expectedLicensePlate, car.LicensePlate);


            car.LicensePlate = "AB";
            Assert.AreEqual("AB", car.LicensePlate);
            car.LicensePlate = "1234567";
            Assert.AreEqual("1234567", car.LicensePlate);


            car.Price = 6000;
            Assert.AreEqual(6000, car.Price);
            car.Price = 1;
            Assert.AreEqual(1,car.Price);

            car.Model = "Ferrari";
            Assert.AreEqual("Ferrari", car.Model);

        }

        [TestMethod()]
        public void InvalidCarTest()
        {

            //Act
            Car car1 = new Car();

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => car1.LicensePlate = "A");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => car1.LicensePlate = "12345678");

            Assert.ThrowsException<ArgumentOutOfRangeException>((() => car1.Price = -1));

            Assert.ThrowsException<ArgumentOutOfRangeException>((() => car1.Model = "CD"));
            Assert.ThrowsException<ArgumentOutOfRangeException>((() => car1.Model = "BCD"));


        }
    }
}