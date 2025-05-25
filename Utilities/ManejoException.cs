using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Utilities
{
    public class ManejoException
    {
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

        public static ActionResult Unauthorized()
        {
            return new ObjectResult(new { codigo = 403, mensaje = "No tienes permisos." }) { StatusCode = 403 };
        }
    }
}
