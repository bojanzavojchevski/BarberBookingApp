using BarberBookingApp.Domain.Enums;
using BarberBookingApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBookingApp.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public Guid ServiceItemId { get; set; }
        public ServiceItem ServiceItems { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime AppointmentTime { get; set; }

        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ConfirmedAt { get; set; }
        public string? DeclineReason { get; set; }


    }
}
