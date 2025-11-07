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
    public class ServiceItemsController : Controller
    {
        private readonly IServiceItemService _service;

        public ServiceItemsController(IServiceItemService service)
        {
            _service = service;
        }

        // GET: ServiceItems
        public async Task<IActionResult> Index()
        {
            var services = await _service.GetAllAsync();
            return View(services);
        }

        // GET: ServiceItems/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var serviceItem = await _service.GetByIdAsync(id);
            if (serviceItem == null)
            {
                return NotFound();
            }

            return View(serviceItem);
        }

        // GET: ServiceItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceItem serviceItem)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceItem);
            }
            serviceItem.Id = Guid.NewGuid();

            await _service.AddAsync(serviceItem);
            await _service.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ServiceItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceItem = await _service.GetByIdAsync(id);

            if (serviceItem == null)
            {
                return NotFound();
            }

            return View(serviceItem);
        }

        // POST: ServiceItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ServiceItem serviceItem)
        {
            if (id != serviceItem.Id)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return View(serviceItem);
            }

            await _service.UpdateAsync(serviceItem);
            await _service.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        // GET: ServiceItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceItem = await _service.GetByIdAsync(id);
            if (serviceItem == null)
            {
                return NotFound();
            }

            return View(serviceItem);
        }

        // POST: ServiceItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var serviceItem = await _service.GetByIdAsync(id);
            if (serviceItem != null)
            {
                await _service.DeleteAsync(serviceItem.Id);
            }

            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool ServiceItemExists(Guid id)
        //{
        //    return _context.ServiceItems.Any(e => e.Id == id);
        //}
    }
}
