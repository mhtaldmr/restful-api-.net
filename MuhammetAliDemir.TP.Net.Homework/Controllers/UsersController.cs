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
            Type type = typeof(UsersController);

            var attr = type.GetMethod("UserCheck");

            var _userName = attr.GetCustomAttributes(typeof(CustomUserCheckAttribute), true)
                .Cast<CustomUserCheckAttribute>()
                .Select(u => u._userName).ToList();

            var _password = attr.GetCustomAttributes(typeof(CustomUserCheckAttribute), true)
                .Cast<CustomUserCheckAttribute>()
                .Select(p => p._password).ToList();



            return _userName.Contains(userName) && _password.Contains(password)
                ? Ok("Welcome!! User is Valid and Exist!")
                : BadRequest("Attention!! User is NOT Valid and Exist!");
        }
    }
}
