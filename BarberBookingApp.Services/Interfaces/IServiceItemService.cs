using BarberBookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBookingApp.Services.Interfaces
{
    public interface IServiceItemService
    {
        Task<ICollection<ServiceItem>> GetAllAsync();
        Task<ServiceItem?> GetByIdAsync(Guid? id);
        Task AddAsync(ServiceItem service);
        Task UpdateAsync(ServiceItem service);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
