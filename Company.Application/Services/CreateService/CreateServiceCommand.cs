using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Application._shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Company.Application.Services.CreateService
{
    public record CreateServiceCommand(string Title, string description, IFormFile? ImageFile) : IRequest<OperationResult>;
}
