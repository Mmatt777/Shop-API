using MediatR;


namespace Shop.Application.Users.Commands.UnassingUserRole
{
    public class UnassingUserRoleCommand : IRequest
    {
        public string UserEmail { get; set; } = default!;
        public string RoleName { get; set; } = default!;
    }
}
