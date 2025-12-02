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
using BarberBookingApp.Domain.Enums;

namespace BarberBookingApp.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _service;
        public readonly IServiceItemService _serviceItemService;

        public AppointmentsController(IAppointmentService service, IServiceItemService serviceItemService)
        {
            _service = service;
            _serviceItemService = serviceItemService;
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
        public async Task<IActionResult> Create()
        {
            var services = await _serviceItemService.GetAllAsync();
            ViewBag.ServiceItemId = new SelectList(services, "Id", "Name");

            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }


            appointment.Status = AppointmentStatus.Booked;

            await _service.AddAsync(appointment);
            await _service.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(appointment);
            }

            await _service.UpdateAsync(appointment);
            await _service.SaveChangesAsync();

            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
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

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var appointment = await _service.GetByIdAsync(id);
            if (appointment != null)
            {
                await _service.DeleteAsync(appointment.Id);
            }

            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool AppointmentExists(Guid id)
        //{
        //    return _context.Appointments.Any(e => e.Id == id);
        //}
    }
}
