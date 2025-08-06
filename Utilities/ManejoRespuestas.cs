using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Utilities
{
    public class ManejoRespuestas
    {
        public static ActionResult Conflict(string email)
        {
            return new ObjectResult(new { codigo = 409, mensaje = $"El email ({email}) ya esta registrado." }) { StatusCode = 409 };
        }
        public static ActionResult NotFound(int id)
        {
            return new ObjectResult(new { codigo = 404, mensaje = $"Recurso Nº ${id} no encontrado." }) { StatusCode = 404};
        }

        public static ActionResult BadRequest(string mensajeError) 
        {
            return new ObjectResult(new { codigo = 400, mensaje = mensajeError }) { StatusCode =  400 };
        }

        public static ActionResult ServerError(string mensajeServer)
        {
            return new ObjectResult (new { codigo = 500, mensaje = mensajeServer }) { StatusCode = 500 };
        }

        public static ActionResult ConflictOfRelation(string mensaje)
        {
            return new ObjectResult(new { codigo = 409, mensaje = mensaje }) { StatusCode = 409 };
        }

        public static ActionResult InvalidCredentials(string mensaje)
        {
            return new ObjectResult(new { codigo = 401, mensaje = mensaje }) { StatusCode = 401 };
        }

        public static ActionResult Unauthorized()
        {
            return new ObjectResult(new { codigo = 401, mensaje = "No tienes permisos." }) { StatusCode = 401 };
        }

        public static ActionResult ValidacionTokenException(string mensaje)
        {
            return new ObjectResult(new { codigo = 401, isValido = false, mensaje = mensaje }) { StatusCode = 401 };
        }

        public static ActionResult ValidacionTokenExitosa(string mensaje)
        {
            return new ObjectResult(new { codigo = 200, isValido = true, mensaje = mensaje }) { StatusCode = 200 };
        }
    }
}
