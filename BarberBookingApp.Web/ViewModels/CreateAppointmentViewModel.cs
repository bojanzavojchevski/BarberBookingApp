using System.ComponentModel.DataAnnotations;

namespace BarberBookingApp.Web.ViewModels
{
    public class CreateAppointmentViewModel
    {
        [Required]
        public Guid ServiceItemId { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentTime { get; set; }
    }
}
