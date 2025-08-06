using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Shop.Application.Users;


namespace Shop.Infrastructure.Authorization.Requirements
{
    public class MinimumAgeRequirementHandler(ILogger<MinimumAgeRequirementHandler> logger,
        IUserContext userContext) : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            var currentUser = userContext.GetCurrentUser();
            
            logger.LogInformation("User: {Email}, date of birth {DateOfBirth} - Handling MinAgeRequirement", currentUser.Email, 
                currentUser.DateOfBirth);

            if(currentUser.DateOfBirth == null)
            {
                logger.LogWarning("User dont enter date of birth");
                context.Fail();
                return Task.CompletedTask;
            }


            if(currentUser.DateOfBirth.Value.AddYears(requirement.MinimumAge) <= DateOnly.FromDateTime(DateTime.Today))
            {
                logger.LogInformation("Age is over 18");
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
                
        }
    }
}
