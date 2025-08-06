using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Users.Commands.AssingUserRole;
using Shop.Application.Users.Commands.UnassingUserRole;
using Shop.Application.Users.Commands.UpdateUserDetails;
using Shop.Domain.Constants;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class IdentityController(IMediator mediator) : ControllerBase
    {
        [HttpPatch("user")]
        [Authorize]
        public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
        
        [HttpPost("userRole")]
        [Authorize(Roles = IdentityRoles.Admin)]
        public async Task<IActionResult> AssingUserRole(AssingUserRoleComand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
        
        [HttpDelete("userRole")]
        [Authorize(Roles = IdentityRoles.Admin)]
        public async Task<IActionResult> UnassingUserRole(UnassingUserRoleCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
    }
}
