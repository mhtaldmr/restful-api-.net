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
    public class RacesController : ControllerBase
    {
        public static List<Race> Races = DataGenerator.Races;

        //GET Method 
        //Getting All the Races in the list
        //GET /Races
        [HttpGet]
        public IActionResult GetRaces()
        {
            //If there is no Races in the list, we will get : #404 Not Found Error
            if (Races.Count() == 0)
                return NotFound("There is no race in the list!");

            return Ok(Races);
        }

        //Getting just one race by id
        //GET /Races/id
        [HttpGet("{id}")]
        public IActionResult GetRaceById(int id)
        {
            //If there is no race in the list, we will get : #404 Not Found Error
            var race = Races.Where(d => d.Id == id).SingleOrDefault();

            if (race is null)
                return NotFound("There is no race in the list!");

            return Ok(race);

        }


        //POST Method
        //Posting race to the list
        //POST /Races
        [HttpPost]
        public IActionResult CreateRace([FromBody] Race race)
        {
            //If there is a race in the list with same id, we will get bad request.
            if (Races.Where(d => d.Id == race.Id).SingleOrDefault() is not null)
                return BadRequest("This race id is already exist in the list.");

            Races.Add(race);
            //Showing the added race again in the response.
            return Created("/races", race);
        }

 
    }
}
