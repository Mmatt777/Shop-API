using Microsoft.Extensions.Logging;
using Shop.Application.Users;
using Shop.Domain.Constants;


namespace Shop.Infrastructure.Authorization.Services
{
    public class ShopAuthorizationService(ILogger<ShopAuthorizationService> logger,
        IUserContext userContext) : IShopAuthorizationService
    {
        public bool IsAuthorize(ResourceOperation resourceOperation)
        {
            var user = userContext.GetCurrentUser();

            logger.LogInformation("User is authorizing {UserEmail}, to {Operation}!",
                user.Email,
                resourceOperation);

            if (resourceOperation == ResourceOperation.Read)
            {
                logger.LogInformation("Read operation - successfull authorization");
                return true;
            }

            if (resourceOperation == ResourceOperation.Create || resourceOperation == ResourceOperation.Update
                || resourceOperation == ResourceOperation.Delete
                && (user.isInRole(IdentityRoles.Admin) || user.isInRole(IdentityRoles.Moderator)))
            {
                logger.LogInformation("Admin or moderator used create, update or delete operation - successfull authorization");
                return true;
            }

            return false;
        }
    }
}
