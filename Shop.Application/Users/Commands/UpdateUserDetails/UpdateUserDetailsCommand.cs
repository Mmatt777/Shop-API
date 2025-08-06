using MediatR;

namespace Shop.Application.Users.Commands.UpdateUserDetails
{
    public class UpdateUserDetailsCommand : IRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
