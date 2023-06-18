using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sending_Emails_SMS.Dtos;
using Sending_Emails_SMS.Services;

namespace Sending_Emails_SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailingController : ControllerBase
    {
        private readonly IMailingService _mailingService;

        public MailingController(IMailingService mailingService)
        {
            _mailingService = mailingService;
        }
        [HttpPost("Send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequestDto dto)
        {
            await _mailingService.SendEmailAsync(dto.ToEmail,dto.Subject,dto.Body,dto.Attachments);
            return Ok();
        }
    }
}
