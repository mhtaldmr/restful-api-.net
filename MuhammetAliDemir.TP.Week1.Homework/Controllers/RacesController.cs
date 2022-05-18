using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        public readonly static List<Race> Races = DataGenerator.Races;

        //***GET Methods***

        //Getting All the Races in the list
        //.../Races
        [HttpGet]
        public IActionResult GetRaces()
        {
            //If there is no Races in the list, we will get : http 404 Not Found Error
            if (Races.Count == 0)
                return NotFound("There is no race in the list!");

            return Ok(Races); //Http 200
        }

        //Getting just one race by id
        //.../Races/id
        [HttpGet("{id}")]
        public IActionResult GetRaceById( int id )
        {
            //If there is no race in the list, we will get : http 404 Not Found Error
            var race = Races.Where(d => d.Id == id).SingleOrDefault();

            if (race is null)
                return NotFound($"There is no race in the list with id = {id}!");

            return Ok(race); //Http 200
        }

        //Getting just one race by id from directly url
        //.../Races/idFromQuery?id=
        [HttpGet("id-from-query")]
        public IActionResult GetRaceByIdFromQuery([FromQuery] int id)
        {
            //If there is NOT a race in the list, we will get : http 404 Not Found Error
            var race = Races.Where(d => d.Id == id).SingleOrDefault();

            if (race is null)
                return NotFound($"There is no race in the list with id = {id}!");

            return Ok(race); //Http 200
        }

        //Getting races according to a spesific property filter defined below
        //.../Races/list?location=
        [HttpGet("list")]
        public IActionResult GetRaceByLocation([FromQuery] string location)
        {
            var races = Races.Where(r => r.Location == location)
                             .OrderBy(r => r.Location)
                             .ToList();

            if (location is null)
                return NotFound("You didnt enter any input into the form!");

            //If there is NOT a race in the list, we will get : http 404 Not Found Error
            if (races.Count == 0)
                return NotFound($"There is no race in the list with input = {location}!");

            return Ok(races); //Http 200
        }


        //***POST Methods***

        //Posting race to the list
        //.../Races
        [HttpPost]
        public IActionResult CreateRace([FromBody] Race race)
        {
            var raceToCheck = Races.Where(d => d.Id == race.Id).SingleOrDefault();

            //If there is a race in the list with same id, we will get bad request.
            if (raceToCheck is not null)
                return BadRequest($"This race with id = {race.Id} is already exist in the list!");

            Races.Add(race);
            //Showing the added race again in the response.
            return Created("/races", Races); //http 201
        }

        //***PUT Methods***

        //Updating the race which was selected by id
        //.../Races/id
        [HttpPut("{id}")]
        public IActionResult UpdateRace( int id, Race race)
        {
            var raceToUpdate = Races.Where(d => d.Id == id).SingleOrDefault();

            //If there is NOT a race in the list with this id, we will get bad request.
            if (raceToUpdate is null)
                return BadRequest($"This race with id = {id} doesnt exist in the list!");

            if (race is null)
                return NotFound($"There is no race in the form with id = {id}!");

            raceToUpdate.Name = raceToUpdate.Name != default ? race.Name : raceToUpdate.Name;
            raceToUpdate.Location = raceToUpdate.Location != default ? race.Location : raceToUpdate.Location;
            raceToUpdate.Length = raceToUpdate.Length != default ? race.Length : raceToUpdate.Length;
            raceToUpdate.NumberOfLaps = raceToUpdate.NumberOfLaps != default ? race.NumberOfLaps : raceToUpdate.NumberOfLaps;
            raceToUpdate.LapRecord = raceToUpdate.LapRecord != default ? race.LapRecord : raceToUpdate.LapRecord;
            raceToUpdate.FirstRaceAt = raceToUpdate.FirstRaceAt != default ? race.FirstRaceAt : raceToUpdate.FirstRaceAt;

            return Ok(raceToUpdate); //Http 200
        }


        //***PATCH Methods***

        //Updating the race which was selected by id, Entering the values in the body
        //.../Races/id
        [HttpPatch("{id}")]
        public IActionResult UpdateRaceWithJsonPatch( int id, [FromBody] JsonPatchDocument<Race> raceToPatch)
        {
            var race = Races.Where(d => d.Id == id).SingleOrDefault();

            if (race is null)
                return BadRequest($"This race with id = {id} doesnt exist in the list!");

            //To apply the changes
            raceToPatch.ApplyTo(race);
            return Ok(race); //Http 200
        }


        //***DELETE Methods***

        //Deleitng the race which was selected by id
        //.../Races/id
        [HttpDelete("{id}")]
        public IActionResult DeleteRace( int id )
        {
            var raceToDelete = Races.Where(d => d.Id == id).SingleOrDefault();

            if (raceToDelete is null)
                return BadRequest($"The race you provided with id = {id} is not exist in the list!");

            Races.Remove(raceToDelete);
            return Ok($"The race with id = {id} has been deleted!"); //Http 200
        }


    }
}
