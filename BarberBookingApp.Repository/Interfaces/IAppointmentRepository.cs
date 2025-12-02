using BarberBookingApp.Domain.Entities;
using BarberBookingApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBookingApp.Repository.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        //Task<ICollection<Appointment>> GetAppointmentByUserAsync(Guid userId);
        //Task<ICollection<Appointment>> GetAppointmentsByDateAsync(DateTime date);
        //Task<bool> IsSlotAvailableAsync(Guid serviceId, DateTime appointmentDate);
    }
}
