using System.ComponentModel.DataAnnotations;

namespace Company.End.ViewModel.Services
{
    public class CreateServiceViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
    public class EditServiceViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? ImageName { get; set; }
        public bool IsVisible { get; set; }
    }
}
