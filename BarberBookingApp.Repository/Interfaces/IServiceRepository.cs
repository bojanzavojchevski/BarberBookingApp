using BarberBookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBookingApp.Repository.Interfaces
{
    public interface IServiceRepository : IGenericRepository<ServiceItem>
    {
    }
}
