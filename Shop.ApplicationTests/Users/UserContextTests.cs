using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using Shop.Domain.Constants;
using System.Security.Claims;
using Xunit;


namespace Shop.Application.Users.Tests
{
    public class UserContextTests
    {
        [Fact()]
        public void GetCurrentUserTest_WithAuthenticatedUser_ShouldReturnCurrentUser()
        {
            // arrange
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

            var dateOfBirth = new DateOnly(1999, 05, 19);

            var claims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, "1"),
                new(ClaimTypes.Email, "test@test.com"),
                new(ClaimTypes.Role, IdentityRoles.Moderator),
                new(ClaimTypes.Role, IdentityRoles.Admin),
                new("DateOfBirth", dateOfBirth.ToString("yyyy-MM-dd"))
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            httpContextAccessorMock.Setup(s => s.HttpContext).Returns(new DefaultHttpContext()
            {
                User = user
            });

            var userContext = new UserContext(httpContextAccessorMock.Object);

            // act

            var currentUser = userContext.GetCurrentUser();

            // asset

            currentUser.Should().NotBeNull();
            currentUser.Id.Should().Be("1");
            currentUser.Email.Should().Be("test@test.com");
            currentUser.Roles.Should().ContainInOrder(IdentityRoles.Moderator, IdentityRoles.Admin);
            currentUser.DateOfBirth.Should().Be(dateOfBirth);
        }

        [Fact()]
        public void GetCurrentUser_WithUserContextNotPresent_ThrowsInvalidOperationException()
        {
            // arrange
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(s => s.HttpContext).Returns((HttpContext)null);

            var userContext = new UserContext(httpContextAccessorMock.Object);

            // act

            Action action = () => userContext.GetCurrentUser();

            // assert 

            action.Should().Throw<InvalidOperationException>()
                .WithMessage("User not found");
        }
    }
}