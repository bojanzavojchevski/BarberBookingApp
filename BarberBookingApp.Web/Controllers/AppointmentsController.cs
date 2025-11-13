using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarberBookingApp.Domain.Entities;
using BarberBookingApp.Web.Data;
using BarberBookingApp.Services.Interfaces;

namespace BarberBookingApp.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var appointments = await _service.GetAllAsync();
            return View(appointments);
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _service.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["ServiceItemId"] = new SelectList(_context.ServiceItems, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceItemId,UserId,AppointmentTime,Status,Id")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointment.Id = Guid.NewGuid();
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceItemId"] = new SelectList(_context.ServiceItems, "Id", "Name", appointment.ServiceItemId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", appointment.UserId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["ServiceItemId"] = new SelectList(_context.ServiceItems, "Id", "Name", appointment.ServiceItemId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", appointment.UserId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ServiceItemId,UserId,AppointmentTime,Status,Id")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceItemId"] = new SelectList(_context.ServiceItems, "Id", "Name", appointment.ServiceItemId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", appointment.UserId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.ServiceItems)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(Guid id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
    }
}
