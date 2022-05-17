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

        //Get Method 
        //Getting All the Teams in the list
        [HttpGet]
        public IActionResult GetTeams()
        {
            //If there is no team in the list, we will get : #404 Not Found Error
            if (Teams.Count() == 0)
                return NotFound("There is no team in the list!");

            return Ok(Teams);
        }

        //Getting just one team by id
        [HttpGet("{id}")]
        public IActionResult GetTeamById(int id)
        {
            //If there is no team in the list, we will get : #404 Not Found Error
            var team = Teams.Where(d => d.Id == id).SingleOrDefault();

            if (team is null)
                return NotFound("There is no team in the list!");

            return Ok(team);

        }
    }
}
