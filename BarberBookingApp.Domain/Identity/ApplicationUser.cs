using BarberBookingApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBookingApp.Domain.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}