﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.Programa
{
    [NotMapped]
    public class GetProgramaDto
    {
        public int Id { get; set; }

        public required string Nombre { get; set; }

        public required string Descripcion { get; set; }

        public required byte Duracion { get; set; }

        public required string Facultad { get; set; }

        public required string RutaImagen { get; set; }
    }
}
