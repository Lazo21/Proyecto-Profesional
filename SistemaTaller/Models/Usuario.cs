//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaTaller.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Id { get; set; }
        public int Estado { get; set; }
        public string Detalle { get; set; }
        public string RoleId { get; set; }
    
        public virtual AspNetRole AspNetRole { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
