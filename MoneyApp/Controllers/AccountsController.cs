using Application.Commands.Account;
using Application.Core;
using Application.Dto.AccountDto;
using Application.Queries;
using Application.Queries.Account;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly Executor executor;

        public AccountsController(Executor executor)
        {
            this.executor = executor;
        }

        [HttpGet]
        public IActionResult Get([FromServices] IGetAllAccounts query)
        {
            return Ok(this.executor.ExecuteQuery(query, 1));
        }

        [HttpPost("AddMoney")]
        public IActionResult addMoney([FromBody] AddMoneyDto request, [FromServices] IAddOrRemoveMoneyToAccount command) 
        {
            this.executor.ExecuteCommand(command, request);
            return NoContent();
        }
        [HttpGet("MoneyPreview")]
        public IActionResult MoneyPreview([FromQuery] PreveiwMoneySearch search, [FromServices]IPreviewMoneyOnAccount query)
        {
            return Ok(this.executor.ExecuteQuery(query, search));
        }

    }
}
