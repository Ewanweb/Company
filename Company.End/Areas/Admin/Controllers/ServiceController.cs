using System.Threading.Tasks;
using Company.Application._shared;
using Company.Application.Services.CreateService;
using Company.Application.Services.Edit;
using Company.Domain.Repositories;
using Company.End.ViewModel.Services;
using Company.Facade.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.End.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceFacade _facade;
        private readonly IServiceRepository _repository;

        public ServiceController(IServiceFacade facade, IServiceRepository repository)
        {
            _facade = facade;
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var services = await _repository.GetAllAsync();
            var viewModelList = services.Select(s => new ServiceViewModel
            {
                Id = s.Id,  
                Title = s.Title,
                Description = s.Description,
                Slug = s.Slug,
                ImageName = s.ImageName,
                CreatedAt = s.CreatedAt,
                IsVisible = s.IsVisible
            }).ToList();
            return View(viewModelList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = new CreateServiceCommand(model.Title, model.Description, model.ImageFile);
            var result = await _facade.Create(command);
            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(model);
            }

            TempData["Success"] = result.Message;
            return RedirectToAction("Index", "Service");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {

            var service = await _repository.GetByIdAsync(id);
            if (service == null)
                return NotFound();

            var model = new EditServiceViewModel
            {
                Id = service.Id,
                Title = service.Title,
                Description = service.Description,
                ImageName = service.ImageName,
                // سایر فیلدها
            };

            return View(model);

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Edit(EditServiceViewModel model)
        {
            var command = new EditServiceCommand(model.Id, model.Title, model.Description, model.ImageFile, model.IsVisible);
            var result = await _facade.Edit(command);
            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(model);
            }

            TempData["Success"] = result.Message;
            return RedirectToAction("Index", "Service");
        }

        [HttpPost]
        [Route("Admin/Service/ToggleVisibility/{id}")]
        public async Task<IActionResult> ToggleVisibility(Guid id)
        {
            var service = await _repository.GetByIdAsync(id);
            if (service == null)
                return NotFound();

            // تغییر وضعیت IsVisible
            if (service.IsVisible)
                service.Hide();
            else
                service.Show();

            await _repository.SaveChangesAsync();

            // بازگشت به صفحه فعلی
            return RedirectToAction("Index", "Service");
        }

    }
}
