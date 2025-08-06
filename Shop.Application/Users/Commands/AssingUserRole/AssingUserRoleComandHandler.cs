using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;

namespace Shop.Application.Users.Commands.AssingUserRole
{
    public class AssingUserRoleComandHandler(ILogger<AssingUserRoleComandHandler> logger,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager) : IRequestHandler<AssingUserRoleComand>
    {
        public async Task Handle(AssingUserRoleComand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Assingning user role: {@Request}", request);

            var user = await userManager.FindByEmailAsync(request.UserEmail);
            if (user == null) throw new NotFoundException(nameof(User), request.UserEmail);

            var userRole = await roleManager.FindByNameAsync(request.RoleName);
            if (userRole == null) throw new NotFoundException(nameof(IdentityRole), request.RoleName);

            await userManager.AddToRoleAsync(user, userRole.Name!);
        }
    }
}
