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
    
    public partial class tbl_categoria_cultura
    {
        public int id_categoria_cultura { get; set; }
        public Nullable<int> id_titulo { get; set; }
        public int id_horario { get; set; }
        public int id_categoria_usuario { get; set; }
        public Nullable<int> valor { get; set; }
        public string descripcion { get; set; }
    
        public virtual tbl_categoria_usuario tbl_categoria_usuario { get; set; }
        public virtual tbl_horario tbl_horario { get; set; }
        public virtual tbl_titulo_cultural tbl_titulo_cultural { get; set; }
    }
}