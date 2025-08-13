using FluentAssertions;
using Shop.Domain.Constants;
using Xunit;


namespace Shop.Application.Users.Tests
{
    public class CurrentUserTests
    {
        //TestMethod_Scenario_ExpectResult
        [Theory()]
        [InlineData(IdentityRoles.Admin)]
        [InlineData(IdentityRoles.User)]
        public void IsInRole_WithMatchingRole_ShouldReturnTrue(string nameRole)
        {
            // arrange
            var currentUser = new CurrentUser("1", "test@test.com", [IdentityRoles.Admin, IdentityRoles.User], null, null);

            // act 

            var isInRole = currentUser.isInRole(nameRole);

            // assert

            isInRole.Should().BeTrue();
        }
        
        [Fact()]
        public void IsInRole_WithNoMatchingRole_ShouldReturnTrue()
        {
            // arrange
            var currentUser = new CurrentUser("1", "test@test.com", [IdentityRoles.Admin, IdentityRoles.User], null, null);

            // act 

            var isInRole = currentUser.isInRole(IdentityRoles.Moderator);

            // assert

            isInRole.Should().BeFalse();
        }
    }
}