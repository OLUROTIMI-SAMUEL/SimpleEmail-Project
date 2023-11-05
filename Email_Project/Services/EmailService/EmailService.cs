using Email_Project.Entities;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using System.Data;
using System.Security.Principal;

namespace Email_Project.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

       // public void Send(string to, string subject, string html, string from = null)
        public void SendEmail(EmailModel request)
        
        {
           try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
                email.To.Add(MailboxAddress.Parse(request.To));                
                email.Subject = request.Subject;               
                email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

                using var smtp = new SmtpClient();
                smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch(Exception ex)
            {
               throw ex;
           }

            //user name: AKIA3SZMDGAHLGPW5TSY
            //pass word: A+Qn+Z2DNXlIiOZUOsFB2TuCh3k79rYnYvCozKdD
            //}

        }

    }
}
