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
        public static List<Team> Teams = DataGenerator.Teams;

        //GET Method 
        //Getting All the Teams in the list
        //GET /Teams
        [HttpGet]
        public IActionResult GetTeams()
        {
            //If there is no team in the list, we will get : #404 Not Found Error
            if (Teams.Count() == 0)
                return NotFound("There is no team in the list!");

            return Ok(Teams);
        }

        //Getting just one team by id
        //GET /Teams/id
        [HttpGet("{id}")]
        public IActionResult GetTeamById(int id)
        {
            //If there is no team in the list, we will get : #404 Not Found Error
            var team = Teams.Where(d => d.Id == id).SingleOrDefault();

            if (team is null)
                return NotFound("There is no team in the list!");

            return Ok(team);
        }

        //POST Method
        //Posting Team to the list
        //POST /Teams
        [HttpPost]
        public IActionResult CreateTeam([FromBody] Team team)
        {
            //If there is a team in the list with same id, we will get bad request.
            if (Teams.Where(d => d.Id == team.Id).SingleOrDefault() is not null)
                return BadRequest("This team id is already exist in the list.");

            Teams.Add(team);
            //Showing the added team again in the response.
            return Created("/teams", team);
        }


    }
}
