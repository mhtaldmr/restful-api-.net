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
        public readonly static List<Race> Races = DataGenerator.Races;

        //***GET Methods***

        //Getting All the Races in the list
        //.../Races
        [HttpGet]
        public IActionResult GetRaces()
        {
            //If there is no Races in the list, we will get : #404 Not Found Error
            if (Races.Count == 0)
                return NotFound("There is no race in the list!");

            return Ok(Races);
        }

        //Getting just one race by id
        //.../Races/id
        [HttpGet("{id}")]
        public IActionResult GetRaceById(int id)
        {
            //If there is no race in the list, we will get : #404 Not Found Error
            var race = Races.Where(d => d.Id == id).SingleOrDefault();

            if (race is null)
                return NotFound($"There is no race in the list with id = {id}!");

            return Ok(race);
        }

        //Getting just one race by id from directly url
        //.../Races/idFromQuery?id=
        [HttpGet("idFromQuery")]
        public IActionResult GetRaceByIdFromQuery([FromQuery] int id)
        {
            //If there is NOT a race in the list, we will get : #404 Not Found Error
            var race = Races.Where(d => d.Id == id).SingleOrDefault();

            if (race is null)
                return NotFound($"There is no race in the list with id = {id}!");

            return Ok(race);
        }


        //***POST Methods***

        //Posting race to the list
        //.../Races
        [HttpPost]
        public IActionResult CreateRace([FromBody] Race race)
        {
            //If there is a race in the list with same id, we will get bad request.
            if (Races.Where(d => d.Id == race.Id).SingleOrDefault() is not null)
                return BadRequest($"This race with id = {race.Id} is already exist in the list!");

            Races.Add(race);
            //Showing the added race again in the response.
            return Created("/races", race); //http 201
        }

        //***PUT Methods***

        //Updating the race which was selected by id
        //.../Races/id
        [HttpPut("{id}")]
        public IActionResult UpdateRace(int id, Race race)
        {
            //If there is NOT a race in the list with same id, we will get bad request.
            var raceToUpdate = Races.Where(d => d.Id == id).SingleOrDefault();

            if (raceToUpdate is null)
                return BadRequest($"This race with id = {id} doesnt exist in the list!");

            if (race is null)
                return NotFound($"There is no race in the form with id = {id}!");

            raceToUpdate.Name = raceToUpdate.Name != default ? race.Name : raceToUpdate.Name;
            raceToUpdate.Location = raceToUpdate.Location != default ? race.Location : raceToUpdate.Location;
            raceToUpdate.Length = raceToUpdate.Length != default ? race.Length : raceToUpdate.Length;
            raceToUpdate.NumberOfLaps = raceToUpdate.NumberOfLaps != default ? race.NumberOfLaps : raceToUpdate.NumberOfLaps;
            raceToUpdate.LapRecord = raceToUpdate.LapRecord != default ? race.LapRecord : raceToUpdate.LapRecord;
            raceToUpdate.FirstRace = raceToUpdate.FirstRace != default ? race.FirstRace : raceToUpdate.FirstRace;

            return Ok(raceToUpdate);
        }


        //***PATCH Methods***

        //Updating the race which was selected by id just selected properties (in this situation is "Name")
        //.../Races/id?Name=
        [HttpPatch("{id}")]
        public IActionResult UpdateName(int id, string Name)
        {
            var raceToPatch = Races.Where(d => d.Id == id).SingleOrDefault();

            if (raceToPatch is null)
                return BadRequest($"This race with id = {id} doesnt exist in the list!");

            if (Name is null)
                return BadRequest("You didnt enter any Name value in the form!");

            raceToPatch.Name = Name;
            return Ok(raceToPatch);
        }


    }
}
