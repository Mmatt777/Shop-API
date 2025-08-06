using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Shop.Application.Users
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }

    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public CurrentUser? GetCurrentUser()
        {
            var user = httpContextAccessor.HttpContext!.User;

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
            var role = user.Claims.Where(u => u.Type == ClaimTypes.Role).Select(u => u.Value);
            var country = user.FindFirst(u => u.Type == "Country")?.Value;
            var dateOfBirthS = user.FindFirst(u => u.Type == "DateOfBirth")?.Value;
            var dateOfBirth = dateOfBirthS == null ? (DateOnly?)null : DateOnly.ParseExact(dateOfBirthS, "yyyy-MM-dd");

            return new CurrentUser(userId, email, role, country, dateOfBirth);
        }
    }
}
