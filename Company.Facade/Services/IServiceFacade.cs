using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Application._shared;
using Company.Application.Services.CreateService;
using Company.Application.Services.Edit;

namespace Company.Facade.Services
{
    public interface IServiceFacade
    {
        Task<OperationResult> Create(CreateServiceCommand command);
        Task<OperationResult> Edit(EditServiceCommand command);
    }
}
