using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain._shared;
using Company.Domain.Consultations;

namespace Company.Domain.MigrationServices
{
    public class MigrationService : BaseEntity
    {
        public string Title { get; private set; } // مثل "ویزای تحصیلی کانادا"
        public string Description { get; private set; }
        public string Slug { get; private set; } // برای URL
        public bool IsVisible { get; private set; }

        public ICollection<ConsultationRequest> ConsultationRequests { get; private set; }

        protected MigrationService() { }

        public MigrationService(string title, string description)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Slug = GenerateSlug(title);
            IsVisible = true;
            CreatedAt = DateTime.Now;
            ConsultationRequests = new List<ConsultationRequest>();
        }

        public void Hide() => IsVisible = false;
        public void Show() => IsVisible = true;

        private string GenerateSlug(string title)
        {
            return title.ToLower().Replace(" ", "-").Replace("‌", "-"); // ساده‌ترین حالت
        }
    }
}
