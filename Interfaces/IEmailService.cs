using GestionUniversidad.Models;

namespace GestionUniversidad.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailFromAplication(MensajeEmail mensajeEmail);
    }
}
