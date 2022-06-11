using Application.Commands.UseCase;
using Application.Core;
using Application.Dto.UseCase;
using Application.Queries.TraceObject;
using Application.Queries.UseCase;
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
    public class AdminController : ControllerBase
    {
        private readonly Executor executor;

        public AdminController(Executor executor)
        {
            this.executor = executor;
        }

        #region UseCaseEndPoints

        [HttpPost]
        public IActionResult NewUseCase([FromBody] NewUseCaseDto request, [FromServices] INewUseCase command)
        {
            this.executor.ExecuteCommand(command, request);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateUseCaseDto([FromBody] UpdateUseCaseDto request, [FromServices] IUpdateUseCase command)
        {
            this.executor.ExecuteCommand(command, request);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetUseCases([FromQuery] UseCaseSearch search, [FromServices] IGetUseCase query)
        {
            return Ok(this.executor.ExecuteQuery(query, search));
        }

        #endregion

        #region UseCasePriviledgeEndPoint


        [HttpPost("Priviledge")]
        public IActionResult NewUseCasePriviledge([FromBody] AddPriviledgeDto request,[FromServices] IAddUseCasePriviledge command) 
        {
            this.executor.ExecuteCommand(command, request);
            return NoContent();
        }

        [HttpDelete("Priviledge/{idToDelete}")]
        public IActionResult RemovePriviledge(int idToDelete,[FromServices] IRemovePriviledgeUseCase command) 
        {
            this.executor.ExecuteCommand(command, idToDelete);
            return NoContent();
        }

        [HttpGet("Priviledge")]
        public IActionResult GetAllPriviledge([FromQuery] PreviewUseCasePriviledges search,[FromServices] IPreviewAllPriveledgesForuser query) 
        {
            return Ok(this.executor.ExecuteQuery(query, search));
        }

        #endregion

        #region GetTraceObject

        [HttpGet("TraceObject")]
        public IActionResult GetAllPriviledge([FromQuery] TraceObjectSearch search, [FromServices] IGetTraceObjects query)
        {
            return Ok(this.executor.ExecuteQuery(query, search));
        }

        #endregion

    }
}
