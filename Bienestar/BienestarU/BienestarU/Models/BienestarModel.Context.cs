﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bd_bienestarEntities : DbContext
    {
        public bd_bienestarEntities()
            : base("name=bd_bienestarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<responsable_categoria> responsable_categoria { get; set; }
        public virtual DbSet<tbl_actividad_empleado> tbl_actividad_empleado { get; set; }
        public virtual DbSet<tbl_actividad_gimnasio> tbl_actividad_gimnasio { get; set; }
        public virtual DbSet<tbl_asignacion_locker> tbl_asignacion_locker { get; set; }
        public virtual DbSet<tbl_categoria> tbl_categoria { get; set; }
        public virtual DbSet<tbl_categoria_cultura> tbl_categoria_cultura { get; set; }
        public virtual DbSet<tbl_categoria_usuario> tbl_categoria_usuario { get; set; }
        public virtual DbSet<tbl_deporte> tbl_deporte { get; set; }
        public virtual DbSet<tbl_entrenador> tbl_entrenador { get; set; }
        public virtual DbSet<tbl_entrenamiento> tbl_entrenamiento { get; set; }
        public virtual DbSet<tbl_grupo> tbl_grupo { get; set; }
        public virtual DbSet<tbl_horario> tbl_horario { get; set; }
        public virtual DbSet<tbl_inscripcion> tbl_inscripcion { get; set; }
        public virtual DbSet<tbl_locker> tbl_locker { get; set; }
        public virtual DbSet<tbl_tarifa> tbl_tarifa { get; set; }
        public virtual DbSet<tbl_tipo_ingreso> tbl_tipo_ingreso { get; set; }
        public virtual DbSet<tbl_titulo_cultural> tbl_titulo_cultural { get; set; }
        public virtual DbSet<tbl_torneo_interno> tbl_torneo_interno { get; set; }
    }
}
