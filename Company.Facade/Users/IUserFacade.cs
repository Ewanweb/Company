using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Application._shared;
using Company.Application.Users.Login;
using Company.Application.Users.Register;

namespace Company.Facade.Users
{
    public interface IUserFacade
    {
        Task<OperationResult> RegisterUser(RegisterUserCommand command);
        Task<OperationResult> LoginUser(LoginUserCommand command);
    }
}
