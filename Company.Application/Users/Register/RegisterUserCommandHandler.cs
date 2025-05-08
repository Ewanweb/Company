using Company.Application._shared;
using Company.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Company.Application.Users.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, OperationResult>
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User(request.FullName, request.Email, null);

                var result = await _userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return OperationResult.Error(errors);
                }

                return OperationResult.Success();
            }
            catch (Exception ex) 
            {
                return OperationResult.Error(ex.Message);

            }
        }
    }
}
