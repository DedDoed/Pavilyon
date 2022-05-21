using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pavilyon.Application.Users.Queries.GetUserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pavilyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        [HttpGet("GetMyData")]
        [Authorize]
        public async Task<ActionResult> GetUserData([FromQuery] GetUserDataQuery query, CancellationToken cancellationToken)
        {
            query.UserId = UserId;
            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}
