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
    
    public partial class responsable_categoria
    {
        public int id_responsable { get; set; }
        public string nombre_responsable { get; set; }
        public string correo_responsable { get; set; }
        public Nullable<int> tel_responsable { get; set; }
        public string coordinador { get; set; }
        public Nullable<int> tel_coordinador { get; set; }
        public string correo_coordinador { get; set; }
        public int id_grupo { get; set; }
        public int id_categoria { get; set; }
    
        public virtual tbl_categoria tbl_categoria { get; set; }
        public virtual tbl_grupo tbl_grupo { get; set; }
    }
}
