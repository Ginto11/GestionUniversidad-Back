using GestionUniversidad.Dtos.Matricula;

namespace GestionUniversidad.Interfaces
{
    public interface IServiceMatricula
    {
        //METODO QUE ME REGRESA UNA LISTA DE ENTIDADES
        Task<IEnumerable<GetMatriculaDto>> FindAll();

        //METODO QUE ME REGRESA UN DTO POR ID
        Task<GetMatriculaDto?> FindDtoById(int id);

         //METODO QUE ME GUARDA UNA ENTIDAD
        Task Save(int id);

        //METODO QUE CANCELA UNA MATRICULA
        Task Cancel(int id);

        //METODO PARA PAGAR UNA MATRICULA
        Task Pay(int id);
    }
}
