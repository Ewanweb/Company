using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Application._shared;
using MediatR;

namespace Company.Application.Users.Login
{
    public record LoginUserCommand(string Email, string Password, bool RememberMe) : IRequest<OperationResult>;
}
    