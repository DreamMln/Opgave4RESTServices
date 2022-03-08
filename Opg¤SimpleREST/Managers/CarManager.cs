using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibraryTests;

namespace Opg_SimpleREST.Managers
{
    public class CarManager
    {
        private static int _nextID = 1;

        //Mock data
        private static List<Car> _data = new List<Car>()
        {
            new Car() {ID = _nextID++, Model = "Lamborghini", Price = 7800, LicensePlate = "y45up"},
            new Car() {ID = _nextID++, Model = "Ferrari", Price = 45890000, LicensePlate = "k373o"},
            new Car() {ID = _nextID++, Model = "Mercedes", Price = 80000, LicensePlate = "r784"}
        };

        //GET All
        public List<Car> GetAll(int? maxPrice)
        {
            List<Car> result = new List<Car>(_data);

            if (maxPrice != null)
            {
                return _data.FindAll(car => car.Price <= maxPrice);
            }
            return result;
        }

        //GET BY ID
        public Car GetByID(int ID)
        {
            foreach (Car car in _data)
            {
                if (car.ID == ID)
                {
                    return car;
                }
            }
            return null;
        }

        //POST
        public Car AddCar(Car newCar)
        {
            newCar.ID = _nextID++;

            _data.Add(newCar);
            return newCar;
        }

        //DELETE
        public Car DeleteCar(int ID)
        {
            var deleteCar = GetByID(ID);

            if (deleteCar == null)
            {
                return null;
            }
            else
            {
                _data.Remove(deleteCar);
                return deleteCar;
            }

        }
    }
}

