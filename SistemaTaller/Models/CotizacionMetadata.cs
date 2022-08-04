using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaTaller.Models
{
    public class CotizacionMetadata
    {
        public int IdCotizacion { get; set; }

        [Display(Name = "Número Cotización")]
        [Required(ErrorMessage = "Número Cotización")]
        public int CodCotizacion { get; set; }

        [Display(Name = "Número Placa")]
        [Required(ErrorMessage = "La placa es requerida")]
        [StringLength(10, ErrorMessage = "El número placa es demasiado largo (Máximo 10 caracteres)")]
        public string NPlaca { get; set; }

        [Display(Name = "Número Cédula")]
        [Required(ErrorMessage = "Número Cédula es requerido")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = " Error La Cédula solo son Números, (Debe contener mínimo 9 caracteres)")]
        public string Cedula { get; set; }

        [Display(Name = "Nombre Cliente")]
        [Required(ErrorMessage = "El Nombre es requerido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z ÑÁÉÍÓÚ ñáéíóú ""'\s-]*$", ErrorMessage = " Slolo letras, Empiezan con mayúscula")]
        [StringLength(50, ErrorMessage = "El Nombre es demasiado largo (Máximo 50 caracteres)")]
        public string NombreClien { get; set; }

        [Display(Name = "Teléfono Cliente")]
        [Required(ErrorMessage = "Número de Teléfono es requerido")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, ErrorMessage = "Solo Números (Debe contener 8 caracteres mínimo)", MinimumLength = 8)]
        public string TelefClien { get; set; }

        [Display(Name = "Correo Cliente")]
        [Required(ErrorMessage = "El Correo es requerido")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Debe de ser un Correo Válido")]
        public string Email { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "La Fecha es requerida")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Servicio")]
        [Required(ErrorMessage = "El servicio es requerido")]
        public string NServicio { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Detalle Reparación")]
        [Required(ErrorMessage = "El Detalle es requerido")]
        [StringLength(200, ErrorMessage = "El Detalle es demasiado largo (Maximo 200 caracteres)")]
        public string Detalle { get; set; }

        [Display(Name = "Monto")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Monto { get; set; }

        [Display(Name = "Monto Descuento")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Descuento { get; set; }

        [Display(Name = "Sub Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal SubTotal { get; set; }

        [Display(Name = "IVA")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal IVA { get; set; }

        [Display(Name = "Monto Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Total { get; set; }

        [Display(Name = "Vigenciá Días")]
        [Required(ErrorMessage = "Número de días es requerido")]
        public int Vigencia { get; set; }

        [Display(Name = " Nombre Empleado")]
        [Required(ErrorMessage = "Empleado es requerido")]
        public string NEmpleado { get; set; }
    }

    [MetadataType(typeof(CotizacionMetadata))]
    public partial class Cotizacion { }
}