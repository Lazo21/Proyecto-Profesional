using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaTaller.Models
{
    public class ServicioMetadata
    {
        public int IdServicio { get; set; }

        [Display(Name = "Número de Servicio")]
        [Required(ErrorMessage = "El código de servicio es requerido")]
        public int CodServicio { get; set; }

        [Display(Name = "Tipo de Servicio")]
        [Required(ErrorMessage = "El tipo de servicio es requerido")]
        [StringLength(60, ErrorMessage = "El tipo de servicio es demasiado largo (Máximo 60 caracteres)")]
        public string NombreServicio { get; set; }
    }

    [MetadataType(typeof(ServicioMetadata))]
    public partial class Servicio { }
}