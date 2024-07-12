using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicio.Shared.DTO
{
    public class ModificarTituloDTO
    {
        [Required(ErrorMessage = "El Id del titulo a modificar es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Estado del titulo a modificar es obligatorio")]
        public bool Activo { get; set; }

        [Required(ErrorMessage = "El Codigo del titulo es obligatorio")]
        [MaxLength(4, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Codigo { get; set; }


        [Required(ErrorMessage = "El Nombre del titulo es obligatorio")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Nombre { get; set; }
    }
}
