using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;


namespace pizza_shop_MVC.Services;


 public class EmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration, string smtpHost)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string v)
        {
            string subject = "Password Reset";
            string message = "Please click on the link to reset your password";
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_configuration["SmtpSettings:SenderName"], _configuration["SmtpSettings:SenderEmail"]));
            emailMessage.To.Add(new MailboxAddress("", toEmail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_configuration["SmtpSettings:Server"], int.Parse(_configuration["SmtpSettings:Port"]), MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_configuration["SmtpSettings:Username"], _configuration["SmtpSettings:Password"]);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

    internal void SendEmail(string email, string v1, string v2)
    {
        throw new NotImplementedException();
    }
}
