using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Application._shared;
using Company.Application.Users.Login;
using Company.Application.Users.Register;
using MediatR;

namespace Company.Facade.Users
{
    public class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;

        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> LoginUser(LoginUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> RegisterUser(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
