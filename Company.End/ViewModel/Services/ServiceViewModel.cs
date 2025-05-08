namespace Company.End.ViewModel.Services
{
    public class ServiceViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } // مثل "ویزای تحصیلی کانادا"
        public string Description { get; set; }
        public string Slug { get; set; } // برای URL
        public bool IsVisible { get; set; }
        public string? ImageName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
