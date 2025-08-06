using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Shop.Domain.Entities;
using System.Security.Claims;

namespace Shop.Infrastructure.Authorization
{
    public class ShopUserClaimsPrincipalFactory(UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager, 
        IOptions<IdentityOptions> options) 
        : UserClaimsPrincipalFactory<User, IdentityRole>(userManager, roleManager, options)
    {
        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var id = await GenerateClaimsAsync(user);

            if (user.FirstName != null)
            {
                id.AddClaim(new Claim(AppClaimTypes.FirstName, user.FirstName));
            }
            if (user.LastName!= null)
            {
                id.AddClaim(new Claim(AppClaimTypes.LastName, user.LastName));
            }
            if (user.Country != null)
            {
                id.AddClaim(new Claim(AppClaimTypes.Country, user.Country));
            }
            if (user.DateOfBirth != null)
            {
                id.AddClaim(new Claim(AppClaimTypes.DateOfBirth, user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
            }

            return new ClaimsPrincipal(id);
            
        }
    }
}
