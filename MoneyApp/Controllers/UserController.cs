using Application.Commands;
using Application.Commands.User;
using Application.Core;
using Application.Dto.UsersDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoneyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Executor executor;

        public UserController(Executor executor)
        {
            this.executor = executor;
        }

        [HttpPost]
        public IActionResult CreateNewUser([FromForm] NewUserDto newUser,[FromServices]ICreateNewUser command)
        {
            newUser.ServerThatHosts = HttpContext.Request.Host.ToString();
            this.executor.ExecuteCommand(command, newUser);
            return NoContent();
        }

        [HttpGet]
        public IActionResult ActivateAccount([FromHeader] string passKey,[FromServices]IActivateUser command)
        {
            this.executor.ExecuteCommand(command, passKey);
            return NoContent();
        }

     
    }
}
