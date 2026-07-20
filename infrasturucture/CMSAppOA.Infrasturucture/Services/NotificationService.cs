using CMSAppOA.Contract.Services;
using CMSAppOA.Domain.Entities;
using CMSAppOA.Domain.Repository;
using System.Net;
using System.Net.Mail;

namespace CMSAppOA.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IGenericRepository<Customer> _customerRepository;

        public NotificationService(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task SendEmailNotification(string message, int customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null || string.IsNullOrEmpty(customer.Email))
            {
                throw new Exception($"Customer with ID {customerId} not found or has no email.");
            }
            var email = customer.Email;
            await SendEmailAsync(email, message);

        }

        public Task SendSmsNotification(string message, int customerId)
        {
            throw new NotImplementedException();
        }

        private async Task SendEmailAsync(string toEmail, string message)
        {
            var fromAddress = new MailAddress("youremailaddress@gmail.com");
            var toAddress = new MailAddress(toEmail);
            const string password = "your app password";

            using var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(fromAddress.Address, password),
                EnableSsl = true
            };

            using var body = new MailMessage(fromAddress, toAddress)
            {
                Subject = "Test Mesaj",
                IsBodyHtml = true,
                Body = $@"
            <h3> Is Teklifi</h3>
       
            <h2 style='letter-spacing:3px'>{message}</h2>
            <p>Kod 5 dəqiqə ərzində cavab verin.</p>
        "
            };

            await smtp.SendMailAsync(body);
        }
    }
}
