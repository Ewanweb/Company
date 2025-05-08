using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Application._shared;
using MediatR;

namespace Company.Application.ConsultationRequests.CreateConsulationRequest
{
    public record CreateConsultationRequestCommand(Guid UserId, Guid ServiceId, string Description) : IRequest<OperationResult>;
}
