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

        //Get Method 
        //Getting All the Races in the list
        [HttpGet]
        public IActionResult GetRaces()
        {
            //If there is no Races in the list, we will get : #404 Not Found Error
            if (Races.Count() == 0)
                return NotFound("There is no race in the list!");

            return Ok(Races);
        }

        //Getting just one race by id
        [HttpGet("{id}")]
        public IActionResult GetRaceById(int id)
        {
            //If there is no race in the list, we will get : #404 Not Found Error
            var race = Races.Where(d => d.Id == id).SingleOrDefault();

            if (race is null)
                return NotFound("There is no race in the list!");

            return Ok(race);


        }
    }
}
