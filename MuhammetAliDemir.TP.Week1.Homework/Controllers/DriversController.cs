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
        public readonly static List<Driver> Drivers = DataGenerator.Drivers;

        //***GET Methods***

        //Getting All the drivers in the list
        //.../Drivers
        [HttpGet]
        public IActionResult GetDrivers()
        {
            //If there is NOT a driver in the list, we will get : #404 Not Found Error
            if (Drivers.Count == 0)
                return NotFound("There is no drivers in the list!");

            return Ok(Drivers);
        }

        //Getting just one driver by id
        //.../Drivers/id
        [HttpGet("{id}")]
        public IActionResult GetDriverById(int id)
        {
            //If there is NOT a driver in the list, we will get : #404 Not Found Error
            var driver = Drivers.Where(d => d.Id == id).SingleOrDefault();

            if (driver is null)
                return NotFound( $"There is no drivers in the list with id = {id}!");

            return Ok(driver);
        }

        //Getting just one driver by id from directly url
        //.../Drivers/idFromQuery?id=
        [HttpGet("idFromQuery")]
        public IActionResult GetDriverByIdFromQuery([FromQuery] int id)
        {
            //If there is NOT a driver in the list, we will get : #404 Not Found Error
            var driver = Drivers.Where(d => d.Id == id).SingleOrDefault();

            if (driver is null)
                return NotFound($"There is no driver in the list with id = {id}!");

            return Ok(driver);
        }


        //***POST Methods***

        //Posting driver to the list
        //.../Drivers
        [HttpPost]
        public IActionResult CreateDriver([FromBody] Driver driver)
        {
            //If there is a driver in the list with same id, we will get bad request.
            var driverToCheck = Drivers.Where(d => d.Id == driver.Id).SingleOrDefault();

            if (driverToCheck is not null)
                return BadRequest( $"This driver with id = {driver.Id} is already exist in the list!");

            Drivers.Add(driver);
            //Showing the added driver again in the response.
            return Created("/drivers",Drivers); //http 201
        }


        //***PUT Methods***

        //Updating the driver which was selected by id
        //.../Drivers/id
        [HttpPut("{id}")]
        public IActionResult UpdateDriver(int id, Driver driver)
        {
            //If there is NOT a driver in the list with same id, we will get bad request.
            var driverToUpdate = Drivers.Where(d => d.Id == id).SingleOrDefault();
            
            if (driverToUpdate is null)
                return BadRequest($"This driver with id = {id} doesnt exist in the list!");

            if (driver is null)
                return NotFound( $"There is no driver in the form with id = {id}!");

            driverToUpdate.Name = driverToUpdate.Name != default ? driver.Name : driverToUpdate.Name;
            driverToUpdate.Team = driverToUpdate.Team != default ? driver.Team : driverToUpdate.Team;
            driverToUpdate.Nationality = driverToUpdate.Nationality != default ? driver.Nationality : driverToUpdate.Nationality;
            driverToUpdate.RaceEntered = driverToUpdate.RaceEntered != default ? driver.RaceEntered : driverToUpdate.RaceEntered;
            driverToUpdate.Podiums = driverToUpdate.Podiums != default ? driver.Podiums : driverToUpdate.Podiums;
            driverToUpdate.Championship = driverToUpdate.Championship != default ? driver.Championship : driverToUpdate.Championship;

            return Ok(driverToUpdate);
        }


        //***PATCH Methods***

        //Updating the driver which was selected by id just selected properties (in this situation is "Team")
        //.../Drivers/id?Team=
        [HttpPatch("{id}")]
        public IActionResult UpdateTeam(int id, string Team)
        {
            var driverToPatch = Drivers.Where(d => d.Id == id).SingleOrDefault();

            if (driverToPatch is null)
                return BadRequest($"This driver with id = {id} doesnt exist in the list!");

            if (Team is null)
                return BadRequest("You didnt enter any Team value in the form!");

            driverToPatch.Team = Team;
            return Ok(driverToPatch);
        }


    }
}
