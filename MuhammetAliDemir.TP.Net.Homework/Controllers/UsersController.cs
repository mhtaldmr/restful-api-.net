using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuhammetAliDemir.TP.Net.Homework.Attributes;
using MuhammetAliDemir.TP.Net.Homework.Data;
using MuhammetAliDemir.TP.Net.Homework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MuhammetAliDemir.TP.Net.Homework.Controllers
{
    //[Route("api/[controller]")]
    [Route("/users")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {

        [HttpPost]
        [CustomUserCheck("admin","password")]
        public IActionResult UserCheck( [FromQuery]string userName,[FromQuery] string password)
        {



            return true/*userName == user.Username && password == user.Password*/
                ? Ok("User is Valid and Exist!")
                : BadRequest("User is NOT Valid and Exist!");
        }
    }
}
