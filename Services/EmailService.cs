using GestionUniversidad.Interfaces;
using GestionUniversidad.Models;
using System.Net;
using System.Net.Mail;

namespace GestionUniversidad.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration config;

        public EmailService(IConfiguration config)
        {
            this.config = config;
        }


        public async Task SendEmailFromAplication(MensajeEmail mensajeEmail)
        {

            try
            {
                string cuerpo = $@"
                <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; border: 1px solid #e0e0e0; border-radius: 8px; padding: 24px; background-color: #f9f9f9;'>
                    <h2 style='color: #333;'>📩 Nuevo mensaje desde el formulario de contacto</h2>
                    <p><strong style='color: #555;'>Nombre:</strong> {mensajeEmail.Nombre}</p>
                    <p><strong style='color: #555;'>Correo:</strong> <a href='mailto:{mensajeEmail.Email}' style='color: #1a73e8;'>{mensajeEmail.Email}</a></p>
                    <p><strong style='color: #555;'>Mensaje:</strong><br>{mensajeEmail.Mensaje}</p>
                    <hr style='margin: 24px 0; border: none; border-top: 1px solid #ddd;'>
                    <p style='font-size: 12px; color: #999;'>Este mensaje fue enviado automáticamente desde el sitio web. Por favor, no respondas a este correo.</p>
                </div>";


                var emailEmisor = config.GetValue<string>("CONFIGURACION_EMAIL:EMAIL");
                var password = config.GetValue<string>("CONFIGURACION_EMAIL:PASSWORD");
                var host = config.GetValue<string>("CONFIGURACION_EMAIL:HOST");
                var puerto = config.GetValue<int>("CONFIGURACION_EMAIL:PUERTO");

                var smtpCliente = new SmtpClient(host, puerto);
                smtpCliente.EnableSsl = true;
                smtpCliente.UseDefaultCredentials = false;
                smtpCliente.Credentials = new NetworkCredential(emailEmisor, password);

                var mensaje = new MailMessage(emailEmisor!, emailEmisor!, "Mensaje desde Instituto Central MZ", cuerpo);
                mensaje.IsBodyHtml = true;

                await smtpCliente.SendMailAsync(mensaje);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
