using Company.Application._shared;
using Company.Application._shared.FileUtil.Interfaces;
using Company.Domain.MigrationServices;
using Company.Domain.Repositories;
using MediatR;

namespace Company.Application.Services.CreateService
{
    internal class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, OperationResult>
    {
        private readonly IServiceRepository _repository;
        private readonly IFileService _fileService;

        public CreateServiceCommandHandler(IServiceRepository repository, IFileService fileService)
        {
            _fileService = fileService;
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            string imageName;

            try
            {
                if (request.ImageFile is not null)
                    imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.Services);
                else
                    imageName = "noImage.png";

                var service = new MigrationService(request.Title, request.description, imageName);

                await _repository.AddAsync(service);
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
