using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Shop.Domain.Constants;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;

namespace Shop.Application.Users.Commands.UnassingUserRole
{
    public class UnassingUserRoleCommandHandler(ILogger<UnassingUserRoleCommandHandler> logger,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager) : IRequestHandler<UnassingUserRoleCommand>
    {
        public async Task Handle(UnassingUserRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Unassing user role : {@Request}", request);

            var user = await userManager.FindByEmailAsync(request.UserEmail);
            if (user == null) throw new NotFoundException(nameof(User), request.UserEmail);

            var userRole = await roleManager.FindByNameAsync(request.RoleName);
            if (user == null) throw new NotFoundException(nameof(IdentityRoles), request.RoleName);

            await userManager.RemoveFromRoleAsync(user, userRole!.Name!);

        }
    }
}
