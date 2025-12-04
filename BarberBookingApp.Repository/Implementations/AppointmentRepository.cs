using BarberBookingApp.Domain.Entities;
using BarberBookingApp.Domain.Enums;
using BarberBookingApp.Repository.Interfaces;
using BarberBookingApp.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BarberBookingApp.Repository.Implementations
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Appointment>> GetAppointmentByUserAsync(Guid userId)
        //{
        //    return await _context.Appointments
        //        .Where(x => x.UserId == userId)
        //        .Include(x => x.Service)
        //        .ToListAsync();
        //}

        //public async Task<IEnumerable<Appointment>> GetAppointmentsByDateAsync(DateTime date)
        //{
        //    return await _context.Appointments
        //        .Where(x => x.AppointmentTime >= date.Date
        //                && x.AppointmentTime < date.Date.AddDays(1)
        //                && x.Status == AppointmentStatus.Booked)
        //        .Include(x => x.Service)
        //        .OrderBy(x => x.AppointmentTime)
        //        .ToListAsync();
        //}

        //public Task<bool> IsSlotAvailableAsync(Guid serviceId, DateTime appointmentDate)
        //{

        //}
    }
} 
