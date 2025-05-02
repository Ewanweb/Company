using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain._shared;

namespace Company.Domain.Consultations
{
    public class ConsultationRequest : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid ServiceId { get; private set; } // فرض بر اینه که سرویس‌های مهاجرتی داریم
        public string Description { get; private set; }
        public ConsultationStatus Status { get; private set; }

        public ConsultationRequest(Guid userId, Guid serviceId, string description)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            ServiceId = serviceId;
            Description = description;
            Status = ConsultationStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public void Approve() => Status = ConsultationStatus.Approved;
        public void Reject() => Status = ConsultationStatus.Rejected;
    }

    public enum ConsultationStatus
    {
        Pending,
        Approved,
        Rejected
    }
    
}
