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
    public class TeamsController : ControllerBase
    {
        public readonly static List<Team> Teams = DataGenerator.Teams;

        //***GET Methods***

        //Getting All the Teams in the list
        //.../Teams
        [HttpGet]
        public IActionResult GetTeams()
        {
            //If there is no team in the list, we will get : http 404 Not Found Error
            if (Teams.Count == 0)
                return NotFound("There is no team in the list!");

            return Ok(Teams);
        }

        //Getting just one team by id
        //.../Teams/id
        [HttpGet("{id}")]
        public IActionResult GetTeamById(int id)
        {
            var team = Teams.Where(d => d.Id == id).SingleOrDefault();

            //If there is no team in the list, we will get : http 404 Not Found Error
            if (team is null)
                return NotFound($"There is no team in the list with id = {id}!");

            return Ok(team); //http 200
        }

        //Getting just one team by id from directly url
        //.../Teams/idFromQuery?id=
        [HttpGet("id-from-query")]
        public IActionResult GetTeamByIdFromQuery([FromQuery] int id)
        {
            var team = Teams.Where(d => d.Id == id).SingleOrDefault();

            //If there is NOT a team in the list, we will get : http 404 Not Found Error
            if (team is null)
                return NotFound($"There is no team in the list with id = {id}!");

            return Ok(team); //http 200
        }

        //Getting teams according to a spesific property filter defined below
        //.../Teams/list?powerunit=
        [HttpGet("list")]
        public IActionResult GetTeamByPowerUnit([FromQuery] string powerUnit)
        {
            var teams = Teams.Where(r => r.PowerUnit == powerUnit)
                             .OrderByDescending(r => r.Championship)
                             .ToList();

            if (powerUnit is null)
                return NotFound("You didnt enter any input into the form!");

            //If there is NOT a team in the list, we will get : http 404 Not Found Error
            if (teams.Count == 0 )
                return NotFound($"There is no team in the list with input = {powerUnit}!");

            return Ok(teams); //http 200
        }


        //***POST Methods***

        //Posting Team to the list
        //.../Teams
        [HttpPost]
        public IActionResult CreateTeam([FromBody] Team team)
        {
            var teamToCheck = Teams.Where(d => d.Id == team.Id).SingleOrDefault();

            //If there is a team in the list with same id, we will get bad request.
            if (teamToCheck is not null)
                return BadRequest( $"This team with id = {team.Id} is already exist in the list!");

            Teams.Add(team);
            //Showing the added team again in the response.
            return Created("/teams", team); //http 201
        }


        //***PUT Methods***

        //Updating the team which was selected by id
        //.../Teams/id
        [HttpPut("{id}")]
        public IActionResult UpdateTeam(int id, Team team)
        {
            var teamToUpdate = Teams.Where(d => d.Id == id).SingleOrDefault();

            //If there is NOT a team in the list with same id, we will get bad request.
            if (teamToUpdate is null)
                return BadRequest($"This team with id = {id} doesnt exist in the list!");

            if (team is null)
                return NotFound($"There is no team in the form with id = {id}!");

            teamToUpdate.Name = teamToUpdate.Name != default ? team.Name : teamToUpdate.Name;
            teamToUpdate.PowerUnit = teamToUpdate.PowerUnit != default ? team.PowerUnit : teamToUpdate.PowerUnit;
            teamToUpdate.Country = teamToUpdate.Country != default ? team.Country : teamToUpdate.Country;
            teamToUpdate.TeamChief = teamToUpdate.TeamChief != default ? team.TeamChief : teamToUpdate.TeamChief;
            //teamToUpdate.Drivers = teamToUpdate.Drivers != default ? team.Drivers : teamToUpdate.Drivers;
            teamToUpdate.Championship = teamToUpdate.Championship != default ? team.Championship : teamToUpdate.Championship;

            return Ok(teamToUpdate); //http 200
        }


        //***PATCH Methods***

        //Updating the team which was selected by id just selected properties (in this situation is "TeamChief")
        //.../Teams/id?TeamChief=
        [HttpPatch("{id}")]
        public IActionResult UpdateTeamChief(int id, string TeamChief)
        {
            var teamToPatch = Teams.Where(d => d.Id == id).SingleOrDefault();

            if (teamToPatch is null)
                return BadRequest($"This team with id = {id} doesnt exist in the list!");

            if (TeamChief is null)
                return BadRequest("You didnt enter any Team value in the form!");

            teamToPatch.TeamChief = TeamChief;
            return Ok(teamToPatch); //http 200
        }


        //***DELETE Methods***

        //Deleitng the team which was selected by id
        //.../Team/id
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            var teamToDelete = Teams.Where(d => d.Id == id).SingleOrDefault();

            if (teamToDelete is null)
                return BadRequest($"The team you provided with id = {id} is not exist in the list!");

            Teams.Remove(teamToDelete);
            return Ok($"The team with id = {id} has been deleted!"); //http 200
        }


    }
}
