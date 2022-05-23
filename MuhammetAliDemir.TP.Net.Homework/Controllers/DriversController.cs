using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MuhammetAliDemir.TP.Net.Homework.Data;
using MuhammetAliDemir.TP.Net.Homework.Entity;
using System.Collections.Generic;
using System.Linq;
using MuhammetAliDemir.TP.Net.Homework.Extensions;
using MuhammetAliDemir.TP.Net.Homework.Services;

namespace MuhammetAliDemir.TP.Net.Homework.Controllers
{
    //[Route("[controller]")]
    [Route("/drivers")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        public readonly static List<Driver> Drivers = DataGenerator.Drivers;
        private readonly IDriverManagerService _driverManagerService;

        public DriversController(IDriverManagerService driverManagerService)
        {
            _driverManagerService = driverManagerService;
        }

        //***GET Methods***

        //Getting All the drivers in the list
        //.../drivers
        [HttpGet]
        public IActionResult GetDrivers()
        {
            //If there is NOT a driver in the list, we will get : http 404 Not Found Error
            if (Drivers.Count == 0)
                return NotFound("There is no drivers in the list!");

            return Ok(Drivers); //Http 200
        }

        //Getting just one driver by id
        //.../drivers/id
        [HttpGet("{id}")]
        public IActionResult GetDriverById( int id )
        {
            var driver = Drivers.Where(d => d.Id == id).SingleOrDefault();

            //If there is NOT a driver in the list, we will get : http 404 Not Found Error
            if (driver is null)
                return NotFound( $"There is no drivers in the list with id = {id}!");
            
            return Ok(driver); //Http 200
        }

        //Getting just one driver by id from directly url
        //.../drivers/id-from-query?id=
        [HttpGet("id-from-query")]
        public IActionResult GetDriverByIdFromQuery([FromQuery] int id)
        {
            var driver = Drivers.Where(d => d.Id == id).SingleOrDefault();

            //If there is NOT a driver in the list, we will get : http 404 Not Found Error
            if (driver is null)
                return NotFound($"There is no driver in the list with id = {id}!");

            return Ok(driver); //Http 200
        }

        //Getting drivers according to a spesific property filter defined below
        //.../drivers/list?raceEntered=
        [HttpGet("list")]
        public IActionResult GetDriverByRaceEntered([FromQuery] int? raceEntered)
        {
            var drivers = Drivers.Where(d => d.RaceEntered >= raceEntered)
                                 .OrderByDescending(d => d.RaceEntered)
                                 .ToList();
            
            if (raceEntered is null)
                return NotFound("You didnt enter any input into the form!");

            //If there is NOT a driver in the list, we will get : http 404 Not Found Error
            if (drivers.Count == 0)
                return NotFound($"There is no driver entered more than {raceEntered} race in the list!");

            return Ok(drivers); //Http 200
        }


        //Getting just PremiumDrivers
        //.../drivers/premium-drivers
        [HttpGet("premium-drivers")]
        public IActionResult GetPremiumDrivers()
        {
            var premiumDrivers = Drivers.Where(d => d.IsPremiumDriver());

            //If there is NOT a driver in the list, we will get : http 404 Not Found Error
            if (premiumDrivers is null)
                return NotFound($"There is no driver in the list with id = !");

            return Ok(premiumDrivers); //Http 200
        }


        //Internal Service Code Example
        //.../drivers/internal-service-error
        [HttpGet("internal-service-error")]
        public IActionResult InternalServiceError()
        {
            return StatusCode(500,"500 Internal Server Error Occured!"); //Http 500
        }


        //***POST Methods***

        //Posting driver to the list
        //.../Drivers
        [HttpPost]
        public IActionResult CreateDriver([FromBody] Driver driver)
        {
            var driverToCheck = Drivers.Where(d => d.Id == driver.Id).SingleOrDefault();

            //If there is a driver in the list with same id, we will get bad request.
            if (driverToCheck is not null)
                return BadRequest( $"This driver with id = {driver.Id} is already exist in the list!");

            Drivers.Add(driver);
            //Showing the added driver again in the response.
            return Created("/drivers",Drivers); //http 201
        }


        //***PUT Methods***

        //Updating the driver which was selected by id
        //.../drivers/id
        [HttpPut("{id}")]
        public IActionResult UpdateDriver( int id, Driver driver)
        {
            var driverToUpdate = Drivers.Where(d => d.Id == id).SingleOrDefault();
            
            //If there is NOT a driver in the list with this id, we will get bad request.
            if (driverToUpdate is null)
                return NotFound($"This driver with id = {id} doesnt exist in the list!");

            if (driver is null)
                return NotFound( $"There is no driver in the form with id = {id}!");

            driverToUpdate.Name = driverToUpdate.Name != default ? driver.Name : driverToUpdate.Name;
            driverToUpdate.Team = driverToUpdate.Team != default ? driver.Team : driverToUpdate.Team;
            driverToUpdate.Nationality = driverToUpdate.Nationality != default ? driver.Nationality : driverToUpdate.Nationality;
            driverToUpdate.RaceEntered = driverToUpdate.RaceEntered != default ? driver.RaceEntered : driverToUpdate.RaceEntered;
            driverToUpdate.Podiums = driverToUpdate.Podiums != default ? driver.Podiums : driverToUpdate.Podiums;
            driverToUpdate.Championship = driverToUpdate.Championship != default ? driver.Championship : driverToUpdate.Championship;
           
            return Ok(driverToUpdate); //Http 200
        }


        //***PATCH Methods***

        //Updating the driver which was selected by id, Entering the values in the body
        //.../drivers/id
        [HttpPatch("{id}")] 
        public IActionResult UpdateDriverWithJsonPatch( int id,[FromBody] JsonPatchDocument<Driver> driverToPatch)
        {
            var driver = Drivers.Where(d => d.Id == id).SingleOrDefault();

            if(driver is null)
                return NotFound($"This driver with id = {id} doesnt exist in the list!");

            //To apply the changes
            driverToPatch.ApplyTo(driver);
            return Ok(driver); //Http 200
        }


        //***DELETE Methods***

        //Deleitng the driver which was selected by id
        //.../Driver/id
        [HttpDelete("{id}")]
        public IActionResult DeleteDriver( int id )
        {
            var driverToDelete = Drivers.Where(d => d.Id == id).SingleOrDefault();

            //if driver doesnt exist then there would be no driver to delete.
            if (driverToDelete is null)
                return NotFound($"The driver you provided with id = {id} is not exist in the list!");

            Drivers.Remove(driverToDelete);
            return NoContent(); //Http 204
        }


    }
}
