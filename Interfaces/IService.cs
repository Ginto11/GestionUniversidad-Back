using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Interfaces
{
    public interface IService <Entidad, Dto> where Entidad : class where Dto : class
    {
        //METODO QUE ME REGRESA UNA LISTA DE ENTIDADES
        Task<IEnumerable<Dto>> FindAll();

        //METODO QUE ME REGRESA UNA ENTIDAD POR ID
        Task<Entidad?> FindById(int id);

        //METODO QUE ME REGRESA UN DTO POR ID
        Task<Dto?> FindDtoById(int id);

        //METODO QUE ME GUARDA UNA ENTIDAD
        Task Save(Entidad entity);

        //METODO QUE ME ACTUALIZA UNA ENTIDAD
        Task Update(Entidad entity);

        //METODO QUE ME ELIMINA UNA ENTIDAD
        Task Delete(Entidad entity);

    }
}
