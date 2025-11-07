using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBookingApp.Domain.Entities
{
    public class ServiceItem : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }
    }
}
