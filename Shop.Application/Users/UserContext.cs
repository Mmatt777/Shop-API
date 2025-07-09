using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Shop.Application.Users
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }

    public class UserContext(IHttpContextAccessor httpContextAccesor) : IUserContext
    {
        public CurrentUser? GetCurrentUser()
        {
            var user = httpContextAccesor.HttpContext!.User;

            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var userId = user.FindFirst(u => u.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(u => u.Type == ClaimTypes.Email)!.Value;
            var roles = user.Claims.Where(u => u.Type == ClaimTypes.Role).Select(u => u.Value);

            return new CurrentUser(userId, email, roles);
        }
    }
}
