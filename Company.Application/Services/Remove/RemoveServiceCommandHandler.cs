using Company.Application._shared;
using Company.Application._shared.FileUtil.Interfaces;
using Company.Domain.MigrationServices;
using Company.Domain.Repositories;
using MediatR;

namespace Company.Application.Services.Remove
{
    internal class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand, OperationResult>
    {
        private readonly IServiceRepository _repository;
        private readonly IFileService _fileService;

        public RemoveServiceCommandHandler(IServiceRepository repository, IFileService fileService)
        {
            _fileService = fileService;
            _repository = repository;
        }
        public async Task<OperationResult> Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync(request.Id);

            if (service == null)
                return OperationResult.Error("سرویسی یافت نشد");

            try
            {
                _repository.Delete(service);
                await _repository.SaveChangesAsync();

                return OperationResult.Success();
            }
            catch (Exception ex)
            {
                return OperationResult.Error($" {ex.Message}عملیات شکست خورد");
            }
        }
    }
}
