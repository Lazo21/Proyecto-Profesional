using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaTaller.Models
{
    public class UsuarioMetadata
    {
        public int IdUsuario { get; set; }

        public string Id { get; set; }

        public int Estado { get; set; }
        [Display(Name = "Detalle del Usuario")]
        [Required(ErrorMessage = " El Detalle del Usuario es requerido")]
        [StringLength(50, ErrorMessage = "El Detalle del Usuario es demasiado largo , (Máximo 50 caracteres)")]

        [DataType(DataType.MultilineText)]
        public string Detalle { get; set; }

        public string RoleId { get; set; }
    }

    [MetadataType(typeof(UsuarioMetadata))]
    public partial class Usuarios { }
}