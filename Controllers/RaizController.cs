using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Controllers
{
    [Route("")]
    [ApiController]
    public class RaizController : ControllerBase
    {
        [HttpGet]
        [Produces("text/html")]
        public ContentResult Index()
        {
            string html = @"
                <!DOCTYPE html>
                <html lang='es'>
                <head>
                    <meta charset='UTF-8'>
                    <title>API REST NovaUniversitas</title>
                    <style>
                        body {
                            font-family: Arial, sans-serif;
                            background-color: #f9f9f9;
                            color: #333;
                            margin: 0;
                            padding: 40px;
                            text-align: center;
                        }
                        header {
                            background-color: #007acc;
                            color: white;
                            padding: 20px;
                            border-radius: 8px;
                        }
                        h1 {
                            margin: 0;
                            font-size: 2em;
                        }
                        h2 {
                            margin-top: 30px;
                            color: #007acc;
                        }
                        .info, .seccion {
                            margin: 30px auto;
                            padding: 20px;
                            max-width: 800px;
                            background: white;
                            border-radius: 10px;
                            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
                            text-align: left;
                        }
                        .info p, .seccion p {
                            margin: 10px 0;
                            font-size: 1.1em;
                        }
                        .enlaces a {
                            display: block;
                            margin: 10px auto;
                            padding: 10px 20px;
                            width: 80%;
                            max-width: 300px;
                            background-color: #007acc;
                            color: white;
                            border-radius: 5px;
                            text-decoration: none;
                            transition: background 0.3s;
                            text-align: center;
                        }
                        .enlaces a:hover {
                            background-color: #005f99;
                        }
                        .estado {
                            margin-top: 15px;
                            display: inline-block;
                            padding: 6px 14px;
                            border-radius: 20px;
                            background-color: #28a745;
                            color: white;
                            font-weight: bold;
                            font-size: 0.9em;
                        }
                        footer {
                            margin-top: 40px;
                            font-size: 0.9em;
                            color: #666;
                        }
                    </style>
                </head>
                <body>
                    <header>
                        <h1>🎓 API Gestión Universidad</h1>
                    </header>

                    <div class='info'>
                        <p><strong>Versión:</strong> 1.0.0</p>
                        <p><strong>Última actualización:</strong> Junio 2025</p>
                        <p><strong>Desarrollador:</strong> Nelson Muñoz</p>
                        <div class='estado'>🟢 En línea</div>
                    </div>

                    <div class='seccion'>
                        <h2>📌 Funcionalidades</h2>
                        <p>✔️ Registro y autenticación de estudiantes.</p>
                        <p>✔️ Gestión de programas académicos.</p>
                        <p>✔️ Asignación y consulta de materias.</p>
                        <p>✔️ Acceso a los datos mediante endpoints REST.</p>
                        <p>✔️ Generación de matriculas mediante procedimientos almacenados.</p>
                    </div>

                    <div class='seccion'>
                        <h2>⚙️ Tecnologías Usadas</h2>
                        <p>• ASP.NET Core 8.0</p>
                        <p>• Entity Framework Core</p>
                        <p>• SQL Server</p>
                        <p>• CORS habilitado para entornos seguros</p>
                    </div>

                    <div class='seccion'>
                        <h2>🧪 Información del proyecto completo.</h2>
                        <div class='enlaces'>
                            <a href='https://github.com/Ginto11/GestionUniversidad-Front' target='_blank'>📘 Ver Documentación Front-End</a>
                            <a href='https://github.com/Ginto11/GestionUniversidad-Back' target='_blank'>📘 Ver Documentación Back-End</a>
                        </div>
                    </div>

                    <div class='seccion'>
                        <h2>📩 Contacto</h2>
                        <p>✉️ Email: salinitosnelson@gmail.com</p>
                        <p>🌐 GitHub: <a href='https://github.com/Ginto11' target='_blank'>Nelson Muñoz</a></p>
                    </div>

                    <footer>
                        <p>© 2025 API REST NovaUniversitas - Todos los derechos reservados</p>
                    </footer>
                </body>
                </html>";

            return Content(html, "text/html");
        }
    }
}
