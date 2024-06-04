using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicio.DB.Data.Entity
{
    [Index(nameof(PersonaId), nameof(TituloId), Name = "Profesion_UQ", IsUnique = true)]
    public class Profesion : EntityBase
    {
        [Required(ErrorMessage = "La persona es obligatoria")]
        public int PersonaId { get; set; }

        public Persona Persona { get; set; }

        [Required(ErrorMessage = "El Titulo es obligatorio")]
        public int TituloId { get; set; }

        public Titulo Titulo { get; set; }

    }
}
