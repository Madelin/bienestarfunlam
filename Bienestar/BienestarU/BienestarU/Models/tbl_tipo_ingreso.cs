//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BienestarU.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_tipo_ingreso
    {
        public int id_tipo_ingreso { get; set; }
        public string ingreso { get; set; }
    
        public virtual tbl_tarifa tbl_tarifa { get; set; }
    }
}