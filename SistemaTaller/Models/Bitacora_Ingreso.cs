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
    
    public partial class Bitacora_Ingreso
    {
        public int IdBitacoraIngreso { get; set; }
        public string Usuario { get; set; }
        public System.DateTime FechaHoraIngreso { get; set; }
        public Nullable<System.DateTime> FechaHoraSalida { get; set; }
        public Nullable<int> TotalMinutos { get; set; }
    }
}
