using Application.Commands.Currency;
using Application.Core;
using Application.Dto.Currency;
using Application.Queries.Currency;
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
    public class CurrencyController : ControllerBase
    {
        private readonly Executor executor;

        public CurrencyController(Executor executor)
        {
            this.executor = executor;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CurrencySearch searching, [FromServices] IGetCurrency query)
        {
            return Ok(executor.ExecuteQuery(query, searching));
        }

        [HttpPost]
        public IActionResult NewCurrency([FromBody] NewCurrencyDto newCurrency, [FromServices] IAddNewCurrency command)
        {
            this.executor.ExecuteCommand(command, newCurrency);
            return NoContent();
        }

        [HttpPatch]
        public IActionResult UpdateCurrency([FromBody] UpdateCurrencyDto updated, [FromServices] IUpdateCurrency command)
        {
            this.executor.ExecuteCommand(command, updated);
            return NoContent();
        }

        [HttpDelete("{idToDelete}")]
        public IActionResult DeleteCurrency(int idToDelete, [FromServices] IRemoveCurrency command)
        {
            this.executor.ExecuteCommand(command, idToDelete);
            return NoContent();
        }

    }
}
