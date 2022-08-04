//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PasicologiaBelen.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Placa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Placa()
        {
            this.Historicoes = new HashSet<Historico>();
        }
    
        public int IdPlaca { get; set; }
        public string PlacaN { get; set; }
        public string Color { get; set; }
        public string Modelo { get; set; }
        public Transmision Transmision { get; set; }
        public Estilo Estilo { get; set; }
        public int IdMarca { get; set; }
        public int IdCliente { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historico> Historicoes { get; set; }
        public virtual Marca Marca { get; set; }
    }
}
