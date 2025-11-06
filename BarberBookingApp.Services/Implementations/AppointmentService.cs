using BarberBookingApp.Domain.Entities;
using BarberBookingApp.Repository.Interfaces;
using BarberBookingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBookingApp.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        public async Task<Appointment?> GetByIdAsync(Guid id)
        {
            return await _appointmentRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Appointment appointment)
        {
            await _appointmentRepository.AddAsync(appointment);
            await _appointmentRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _appointmentRepository.Update(appointment);
            await _appointmentRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment != null)
            {
                _appointmentRepository.Delete(appointment);
                await _appointmentRepository.SaveChangesAsync();
            }
        }
    }
}
