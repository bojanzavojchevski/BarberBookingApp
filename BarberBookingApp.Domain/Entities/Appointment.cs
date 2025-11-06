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
        public Guid ServiceId { get; set; }
        public ServiceItem ServiceItems { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime AppointmentTime { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Booked;
    }
}
