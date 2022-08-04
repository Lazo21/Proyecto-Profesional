using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaTaller.Models
{
    public class HistoricoMetadata
    {
        public int IdHistorico { get; set; }

        [Display(Name = "Placa")]
        [Required(ErrorMessage = "La placa es requerida")]
        public int IdPlaca { get; set; }

        [Display(Name = "Número Cédula")]
        [Required(ErrorMessage = "Número Cédula es requerido")]
        public int IdCliente { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Nombre es requerido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z ÑÁÉÍÓÚ ñáéíóú ""'\s-]*$", ErrorMessage = " Slolo letras, Empiezan con mayúscula")]
        [StringLength(50, ErrorMessage = "El Nombre es demasiado largo (Maximo 50 caracteres)")]
        public string Nombre { get; set; }

        [Display(Name = "Servicio")]
        [Required(ErrorMessage = "El servicio es requerido")]
        public int IdServicio { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Detalle")]
        [Required(ErrorMessage = "El Datalle es requerido")]
        [StringLength(300, ErrorMessage = "El Detalle es demasiado largo (Maximo 300 caracteres)")]
        public string Detalle { get; set; }

        [Display(Name = "Fecha Entrada")]
        [Required(ErrorMessage = "La Fecha Entrada es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaEntrada { get; set; }

        [Display(Name = "Fecha Reparación")]
        [Required(ErrorMessage = "La Fecha Reparación es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaReparacion { get; set; }

        [Display(Name = "Fecha Salida")]
        [Required(ErrorMessage = "La Fecha Salida es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaSalida { get; set; }

        [Display(Name = "Empleado")]
        [Required(ErrorMessage = "Empleado es requerido")]
        public int IdEmpleado { get; set; }
    }

    [MetadataType(typeof(HistoricoMetadata))]
    public partial class Historico { }
}