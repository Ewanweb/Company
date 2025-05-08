using Company.Application._shared;
using Company.Domain.Consultations;
using Company.Domain.Repositories;
using MediatR;

namespace Company.Application.ConsultationRequests.CreateConsulationRequest
{
    internal class CreateConsultationRequestCommandHandler : IRequestHandler<CreateConsultationRequestCommand, OperationResult>
    {
        private readonly IConsulationRepository _repository;

        public CreateConsultationRequestCommandHandler(IConsulationRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(CreateConsultationRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = new ConsultationRequest(request.UserId, request.ServiceId, request.Description);

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}
