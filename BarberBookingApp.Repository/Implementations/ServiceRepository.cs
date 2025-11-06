using BarberBookingApp.Domain.Entities;
using BarberBookingApp.Repository.Interfaces;
using BarberBookingApp.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBookingApp.Repository.Implementations
{
    public class ServiceRepository : GenericRepository<ServiceItem>, IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
