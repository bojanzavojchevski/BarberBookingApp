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
    public class ServiceItemService : IServiceItemService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceItemService(IServiceRepository serviceRepository) 
        {
            _serviceRepository = serviceRepository;
        }


        public async Task<IEnumerable<ServiceItem>> GetAllAsync()
        {
            return await _serviceRepository.GetAllAsync();
        }

        public async Task<ServiceItem?> GetByIdAsync(Guid id)
        {
            return await _serviceRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(ServiceItem service)
        {
            await _serviceRepository.AddAsync(service);
            await _serviceRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(ServiceItem service)
        {
            _serviceRepository.Update(service);
            await _serviceRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            if(service != null)
            {
                _serviceRepository.Delete(service);
                await _serviceRepository.SaveChangesAsync();
            }
        }
    }
}
