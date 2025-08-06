
namespace Shop.Application.Users
{
    public record class CurrentUser(string Id,
        string Email, 
        IEnumerable<string> Roles,
        string? Country, 
        DateOnly? DateOfBirth)
    {
        public bool isInRole(string role) => Roles.Contains(role);
    }
}
