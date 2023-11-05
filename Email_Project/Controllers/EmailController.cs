using Email_Project.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace Email_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        [HttpPost("register")]

        public IActionResult SendEmail(/*string body*/
                EmailModel request)
        {

            // emailService.SendEmail(request);
            // return Ok();

            //// emailService.Send(request, Request.Headers["origin"]);
            //// return Ok(new { message = "Registration successful, please check your email for verification instructions" });

            if (request == null)
            {
                return BadRequest("Invalid request!!");
            }

            try
            {
                emailService.SendEmail(request);
                return Ok("Email was sent successfully!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Email sending failed: " + ex.Message);
            }
        }
    }
}  
