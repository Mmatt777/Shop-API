using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Shop.Domain.Entities;
using Shop.Domain.Exceptions;


namespace Shop.Application.Users.Commands.UpdateUserDetails
{
    public class UpdateUserDetailsCommandHandler(ILogger<UpdateUserDetailsCommandHandler> logger,
        IUserContext userContext,
        IUserStore<User> userStore) 
        : IRequestHandler<UpdateUserDetailsCommand>
    {
        public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();
            logger.LogInformation("Updating user: {userId} details with {@Request}", user!.Id,  request);

            var dbUser = await userStore.FindByIdAsync(user.Id, cancellationToken);

            if(dbUser == null)
            {
                throw new NotFoundException(nameof(User), user.Id);
            }

            dbUser.FirstName = request.FirstName;
            dbUser.LastName = request.LastName;
            dbUser.Country = request.Country;
            dbUser.DateOfBirth = request.DateOfBirth;

            await userStore.UpdateAsync(dbUser, cancellationToken);
        }
    }
}
