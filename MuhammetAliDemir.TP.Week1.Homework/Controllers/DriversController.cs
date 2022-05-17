using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuhammetAliDemir.TP.Week1.Homework.Data;
using MuhammetAliDemir.TP.Week1.Homework.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MuhammetAliDemir.TP.Week1.Homework.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        public static List<Driver> Drivers = DataGenerator.Drivers;

        //GET Method
        //Getting All the drivers in the list
        //GET /Drivers
        [HttpGet]
        public IActionResult GetDrivers()
        {
            //If there is no driver in the list, we will get : #404 Not Found Error
            if (Drivers.Count() == 0)
                return NotFound("There is no drivers in the list!");

            return Ok(Drivers);
        }

        //Getting just one driver by id
        //GET /Drivers/id
        [HttpGet("{id}")]
        public IActionResult GetDriverById(int id)
        {
            //If there is no driver in the list, we will get : #404 Not Found Error
            var driver = Drivers.Where(d => d.Id == id).SingleOrDefault();

            if (driver is null)
                return NotFound("There is no drivers in the list!");

            return Ok(driver);
        }


        //POST Method
        //Posting driver to the list
        //POST /Drivers
        [HttpPost]
        public IActionResult CreateDriver([FromBody] Driver driver)
        {
            //If there is a driver in the list with same id, we will get bad request.
            if (Drivers.Where(d => d.Id == driver.Id).SingleOrDefault() is not null)
                return BadRequest("This driver id is already exist in the list.");

            Drivers.Add(driver);
            //Showing the added driver again in the response.
            return Created("/drivers",driver);
        }



    }
}
