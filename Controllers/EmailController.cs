using GestionUniversidad.Interfaces;
using GestionUniversidad.Models;
using GestionUniversidad.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;
        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost]
        public async Task<ActionResult> Enviar(MensajeEmail mensajeEmail)
        {
            try
            {
                await emailService.SendEmailFromAplication(mensajeEmail);
                return Ok();
            }
            catch(Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
            }
        }
    }
}
