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

        //Get Method 
        //Getting All the drivers in the list
        [HttpGet]
        public IActionResult GetDrivers()
        {
            //If there is no driver in the list, we will get : #404 Not Found Error
            if (Drivers.Count() == 0)
                return NotFound("There is no drivers in the list!");

            return Ok(Drivers);
        }

        //Getting just one driver by id
        [HttpGet("{id}")]
        public IActionResult GetDriverById(int id)
        {
            //If there is no driver in the list, we will get : #404 Not Found Error
            var driver = Drivers.Where(d => d.Id == id).SingleOrDefault();

            if (driver is null )
                return NotFound("There is no drivers in the list!");

            return Ok(driver);
        }





    }
}
