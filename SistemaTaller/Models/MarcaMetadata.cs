using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaTaller.Models
{
    public class MarcaMetadata
    {
        public int IdMarca { get; set; }

        [Display(Name = "Número de Marca")]
        [Required(ErrorMessage = "El Código de marca es requerido")]
        public int CodMarca { get; set; }

        [Display(Name = "Tipo de Marca")]
        [Required(ErrorMessage = "El tipo de marca es requerido")]
        [StringLength(60, ErrorMessage = "El tipo de marca es demasiado largo (Maximo 60 caracteres)")]
        public string NombreMarca { get; set; }
    }

    [MetadataType(typeof(MarcaMetadata))]
    public partial class Marca { }
}