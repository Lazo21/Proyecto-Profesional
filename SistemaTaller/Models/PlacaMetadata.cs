using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaTaller.Models
{
    public class PlacaMetadata
    {
        public int IdPlaca { get; set; }

        [Display(Name = "Placa")]
        [Required(ErrorMessage = "La placa es requerida")]
        [StringLength(10, ErrorMessage = "El número placa es demasiado largo (Máximo 10 caracteres)")]
        public string PlacaN { get; set; }

        [Display(Name = "Color")]
        [Required(ErrorMessage = "Color es requerido")]
        [StringLength(50, ErrorMessage = "El color es demasiado largo")]
        public string Color { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "El Modelo es requerido")]
        public int Modelo { get; set; }


        [Display(Name = "Transmisión")]
        [Required(ErrorMessage = "Seleccione una opcion para Transmisión")]
        public int Transmision { get; set; }

        [Display(Name = "Estilo")]
        [Required(ErrorMessage = "Seleccione una opcion para Estilo")]
        public int Estilo { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "La Marca es requerida")]
        public int IdMarca { get; set; }

        [Display(Name = "Cedula")]
        [Required(ErrorMessage = "La Cédula es requerida")]
        public int IdCliente { get; set; }
    }

    [MetadataType(typeof(PlacaMetadata))]
    public partial class Placa { }
}