using BarberBookingApp.Domain.Entities;
using BarberBookingApp.Repository.Interfaces;
using BarberBookingApp.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBookingApp.Repository.Implementations
{
    public class ServiceItemRepository : GenericRepository<ServiceItem>, IServiceItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
