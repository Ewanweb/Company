using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.Consultations;
using Microsoft.AspNetCore.Identity;

namespace Company.Domain.Users
{
    public class User : IdentityUser<Guid> // استفاده از Guid به عنوان کلید
    {
        public string FullName { get; private set; }
        public bool IsActive { get; private set; } = true;
        public DateTime CreatedAt { get; private set; }

        protected User() { } // EF نیاز دارد

        public ICollection<ConsultationRequest> ConsultationRequests { get; set; }


        public User(string fullName, string email, string phoneNumber)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
            UserName = email;
            PhoneNumber = phoneNumber;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public bool CanRequestConsultation() => IsActive;

    }
}
