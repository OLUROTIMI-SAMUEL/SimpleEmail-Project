using Email_Project.Entities;

namespace Email_Project.Services.EmailService
{
  
    public interface IEmailService
    {
         void SendEmail(EmailModel request);
   
    }
}
