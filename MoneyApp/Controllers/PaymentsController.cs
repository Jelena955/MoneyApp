using Application.Commands.PaymentCategory;
using Application.Commands.Payments;
using Application.Commands.PaymentType;
using Application.Core;
using Application.Dto.Payments;
using Application.Queries.PaymentCategory;
using Application.Queries.PaymentType;
using Application.Queries.Payments;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MoneyApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly Executor executor;

        public PaymentsController(Executor executor)
        {
            this.executor = executor;
        }

        #region PaymentsEndPoints

        [HttpPost]
        public IActionResult MakeNewPayment([FromBody] NewPaymentDto request, [FromServices] INewPayment command)
        {
            this.executor.ExecuteCommand(command, request);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Getpayments([FromQuery] PaymentSearch search, [FromServices] IGetPaymentForUser query)
        {
            return Ok(this.executor.ExecuteQuery(query, search));
        }

        [HttpGet("OneAccount")]
        public IActionResult GetPaymentsForAccount([FromQuery] PaymentSearchForOne search, [FromServices] IGetPaymentForOneAccount query) 
        {
            return Ok(this.executor.ExecuteQuery(query, search));
        }
        [HttpDelete("{idToDelete}")]
        public IActionResult DeletePaymentType(int idToDelete, [FromServices] IRemovePayment command)
        {
            this.executor.ExecuteCommand(command, idToDelete);
            return NoContent();
        }

        #endregion

        #region PaymentTypeEndPoints

        [HttpPut("PaymentType")]
        public IActionResult UpdatePaymentType([FromBody] UpdatePaymentTypeDto request, [FromServices] IUpdatePaymentType command)
        {
            this.executor.ExecuteCommand(command, request);
            return NoContent();
        }


        [HttpPost("PaymentType")]
        public IActionResult NewPaymentType([FromBody] NewPaymentTypeDto request, [FromServices] INewPaymentType command)
        {
            this.executor.ExecuteCommand(command, request);
            return NoContent();
        }

        [HttpGet("PaymentType")]
        public IActionResult GetPaymentType([FromQuery] PaymentTypeSearch search, [FromServices] IGetPaymentTypes query)
        {
            return Ok(this.executor.ExecuteQuery(query, search));
        }

        [HttpDelete("PaymentType/{idToDelete}")]
        public IActionResult DeletePaymentType(int idToDelete,[FromServices] IRemovePaymentType command)
        {
            this.executor.ExecuteCommand(command, idToDelete);
            return NoContent();
        }

        #endregion

        #region PaymentCategoryEndPoints

        [HttpGet("PaymentCategory")]
        public IActionResult PaymentCategories([FromServices] IGetAllCategories query)
        {
            return Ok(this.executor.ExecuteQuery(query, 1));
        }

        [HttpPost("PaymentCategory")]
        public IActionResult NewPaymentCategory([FromBody] NewPaymentCategoryDto request, [FromServices] INewPaymentCategory command)
        {
            this.executor.ExecuteCommand(command, request);
            return NoContent();
        }

        [HttpPatch("PaymentCategory")]
        public IActionResult UpdatePaymentCategory([FromBody] UpdatePaymentCategoryDto request, [FromServices] IUpdatePaymentCategory command)
        {
            this.executor.ExecuteCommand(command, request);
            return NoContent();
        }
        [HttpDelete("PaymentCategory/{idToDelete}")]
        public IActionResult DeletePaymentCategory(int idToDelete, [FromServices] IPaymentCategoryDelete command)
        {
            this.executor.ExecuteCommand(command, idToDelete);
            return NoContent();
        }

        #endregion

       
    }
}
