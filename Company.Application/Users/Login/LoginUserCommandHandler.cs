using Company.Application._shared;
using Company.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Company.Application.Users.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, OperationResult>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public LoginUserCommandHandler(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<OperationResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                return OperationResult.Error("ایمیل یا کلمه ورود نامعتبر است");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);

            if (!result.Succeeded)
                return OperationResult.Error("رمز عبور یا ایمیل اشتباه است");

            return OperationResult.Success("ورود موفقیت‌آمیز بود");

        }
    }
}
    