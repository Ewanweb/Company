using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Application._shared;
using Company.Application.Services.CreateService;
using Company.Application.Services.Edit;
using MediatR;

namespace Company.Facade.Services
{
    public class ServiceFacade : IServiceFacade
    {
        private readonly IMediator _mediator;

        public ServiceFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> Create(CreateServiceCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditServiceCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
