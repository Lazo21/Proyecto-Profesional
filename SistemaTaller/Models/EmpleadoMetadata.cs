using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaTaller.Models
{
    public class EmpleadoMetadata
    {
        public int IdEmpleado { get; set; }

        [Display(Name = "Cédula Empleado")]
        [Required(ErrorMessage = "Numero de Cédula es requerido")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = " Error La Cédula solo son Números, (Debe contener mínimo 9 caracteres)")]
        public string Cedula { get; set; }

        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "El Nombre es requerido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z ÑÁÉÍÓÚ ñáéíóú ""'\s-]*$", ErrorMessage = " Slolo letras, Empiezan con mayúscula")]
        [StringLength(100, ErrorMessage = "El Nombre es demasiado largo (Maximo 100 caracteres)")]
        public string Nombre { get; set; }

        [Display(Name = "Télefono")]
        [Required(ErrorMessage = "Número de Teléfono es requerido")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20, ErrorMessage = "Solo Números (Debe contener mínimo 9 caracteres)", MinimumLength = 8)]
        public string Telefono { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La Dirección es requerida")]
        [StringLength(100, ErrorMessage = "La Dirección es demasiado larga (Máximo 100 caracteres)")]
        public string Direccion { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El Correo es requerido")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Debe de ser un Correo Válido")]
        [StringLength(50, ErrorMessage = "El Correo del Cliente es demasiado largo (Máximo 50 caracteres)")]
        public string Email { get; set; }
    }

    [MetadataType(typeof(EmpleadoMetadata))]
    public partial class Empleado { }
}