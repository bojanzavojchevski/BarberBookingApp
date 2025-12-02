using BarberBookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBookingApp.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<ICollection<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(Guid? id);
        Task AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
