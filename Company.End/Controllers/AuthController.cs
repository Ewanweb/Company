using Company.Application._shared;
using Company.Application.Users;
using Company.Application.Users.Login;
using Company.Application.Users.Register;
using Company.End.ViewModel;
using Company.Facade.Users;
using Microsoft.AspNetCore.Mvc;

namespace Company.End.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserFacade _facade;

        public AuthController(IUserFacade facade)
        {
            _facade = facade;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = new RegisterUserCommand(model.FullName, model.Email, model.Password);

            var result = await _facade.RegisterUser(command);

            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(model);
            }

            TempData["Success"] = result.Message;
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = new LoginUserCommand(model.Email, model.Password, model.RememberMe);

            var result = await _facade.LoginUser(command);

            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(model);
            }

            TempData["Success"] = result.Message;
            return RedirectToAction("Index", "Home");
        }
    }
}
