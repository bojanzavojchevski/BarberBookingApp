namespace BarberBookingApp.Web.Configuration
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public bool UseSsl { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
