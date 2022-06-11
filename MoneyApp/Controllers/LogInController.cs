using Application.Commands.Account;
using Application.Core;
using Microsoft.AspNetCore.Mvc;
using MoneyApp.Core;
using System;
using System.Linq;

namespace MoneyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly JwtGenerator generator;
        private readonly IAddSalary salaryAdder;
        public LogInController(JwtGenerator generator, [FromServices] IAddSalary salaryAdder)
        {
            this.generator = generator;
            this.salaryAdder = salaryAdder;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginCredential Credential) 
        {
            var token = generator.MakeToken(Credential.UserName, Credential.Password);

            //Succesfully logged in, quick check up of sallary

            this.salaryAdder.Execute(Int32.Parse((token.ElementAt(1))));

            return Ok(new { Token = token.FirstOrDefault() });
        }
    }

    public class LoginCredential 
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
