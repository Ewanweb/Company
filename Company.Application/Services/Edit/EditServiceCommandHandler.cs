using Company.Application._shared;
using Company.Application._shared.FileUtil.Interfaces;
using Company.Domain.MigrationServices;
using Company.Domain.Repositories;
using MediatR;

namespace Company.Application.Services.Edit
{
    internal class EditServiceCommandHandler : IRequestHandler<EditServiceCommand, OperationResult>
    {
        private readonly IServiceRepository _repository;
        private readonly IFileService _fileService;

        public EditServiceCommandHandler(IServiceRepository repository, IFileService fileService)
        {
            _fileService = fileService;
            _repository = repository;
        }
        public async Task<OperationResult> Handle(EditServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync(request.Id);
            if (service == null)
                return OperationResult.Error("سرویسی یافت نشد");

            string? imageName;
            try
            {
                if (request.ImageFile is not null)
                {
                    if(service.ImageName is "noImage.png")
                        imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.Services);

                    _fileService.DeleteFile(Directories.Services, service.ImageName);
                    imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.Services);
                }
                else
                    imageName = service.ImageName;

                service.Edit(request.Title, request.description, imageName);


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
