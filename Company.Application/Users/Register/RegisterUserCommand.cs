using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Application._shared;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Company.Application.Users.Register
{
    public record RegisterUserCommand(string FullName, string Email, string Password) : IRequest<OperationResult>;
}
