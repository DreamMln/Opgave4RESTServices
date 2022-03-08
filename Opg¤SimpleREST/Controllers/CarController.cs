using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibraryTests;
using Microsoft.AspNetCore.Http;
using Opg_SimpleREST.Managers;

namespace Opg_SimpleREST.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private CarManager _manager = new CarManager();

        // GET ALL api/Car ? filter
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get([FromQuery] int? maxPrice)
        {
            IEnumerable<Car> cars = null;
            cars = _manager.GetAll(maxPrice);

            if (cars.Count() <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(cars);
            }
        }

        // GET BY ID api/<CarController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("{ID}")]
        public ActionResult<Car> GetID(int ID)
        {
            Car result = _manager.GetByID(ID);

            if (result == null)
            {
                return NotFound("No such car found, id: " + ID);
            }
            else
            {
                return Ok(result);
            }
        }

        // POST api/<CarController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car newCar)
        {
            Car result = _manager.AddCar(newCar);
            return Created($"/api/Car/{result.ID}", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //DELETE api/<CarController>
        [HttpDelete("{ID}")]
        public ActionResult<Car> Delete(int ID)
        {

            Car result = _manager.DeleteCar(ID);
            if (result == null)
            {
                return NotFound("No such item, id: " + ID);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}

