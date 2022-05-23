using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pavilyon.Application.Projects.Commands.CreateProject;
using Pavilyon.Application.Projects.Commands.DeleteProject;
using Pavilyon.Application.Projects.Commands.UpdateProject;
using Pavilyon.Application.Projects.Queries.GetProjectDescription;
using Pavilyon.Application.Projects.Queries.GetProjectList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pavilyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : BaseController
    {

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll([FromQuery] GetProjectListQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet("Get")]
        //[Authorize]
        public async Task<ActionResult> Get([FromQuery] GetProjectDescriptionQuery query, CancellationToken cancellationToken)
        {
            //query.UserId = UserId;
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpPost("Create")]
        //[Authorize]
        public async Task<ActionResult> Create(CreateProjectCommand command, CancellationToken cancellationToken)
        {
            //command.UserId = UserId;
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut("Update")]
        //[Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateProjectCommand command, CancellationToken cancellationToken)
        {
            //command.UserId = UserId;
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("Delete")]
        //[Authorize]
        public async Task<IActionResult> Delete(DeleteProjectCommand command, CancellationToken cancellationToken)
        {
            //command.UserId = UserId;
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
