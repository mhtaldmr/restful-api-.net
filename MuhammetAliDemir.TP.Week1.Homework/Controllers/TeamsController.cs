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
            //If there is no team in the list, we will get : #404 Not Found Error
            if (Teams.Count == 0)
                return NotFound("There is no team in the list!");

            return Ok(Teams);
        }

        //Getting just one team by id
        //.../Teams/id
        [HttpGet("{id}")]
        public IActionResult GetTeamById(int id)
        {
            //If there is no team in the list, we will get : #404 Not Found Error
            var team = Teams.Where(d => d.Id == id).SingleOrDefault();

            if (team is null)
                return NotFound($"There is no team in the list with id = {id}!");

            return Ok(team);
        }

        //Getting just one team by id from directly url
        //.../Teams/idFromQuery?id=
        [HttpGet("idFromQuery")]
        public IActionResult GetTeamByIdFromQuery([FromQuery] int id)
        {
            //If there is NOT a team in the list, we will get : #404 Not Found Error
            var team = Teams.Where(d => d.Id == id).SingleOrDefault();

            if (team is null)
                return NotFound($"There is no team in the list with id = {id}!");

            return Ok(team);
        }


        //***POST Methods***

        //Posting Team to the list
        //.../Teams
        [HttpPost]
        public IActionResult CreateTeam([FromBody] Team team)
        {
            //If there is a team in the list with same id, we will get bad request.
            if (Teams.Where(d => d.Id == team.Id).SingleOrDefault() is not null)
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
            //If there is NOT a team in the list with same id, we will get bad request.
            var teamToUpdate = Teams.Where(d => d.Id == id).SingleOrDefault();

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

            return Ok(teamToUpdate);
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
            return Ok(teamToPatch);
        }


    }
}
