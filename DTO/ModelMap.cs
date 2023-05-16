
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Project.DTO
{
    public partial class ModelMap : DbContext
    {
        public ModelMap()
               : base("name=ModelMap")
        {
        }
        public virtual DbSet<Notificacion> Notificacion { get; set; }
        public virtual DbSet<Transporte> Transporte { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transporte>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Transporte>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Transporte>()
                .Property(e => e.Latitud)
                .IsUnicode(false);

            modelBuilder.Entity<Transporte>()
                .Property(e => e.Longitud)
                .IsUnicode(false);

            modelBuilder.Entity<Transporte>()
                .HasMany(e => e.Ubicacion)
                .WithOptional(e => e.Transporte)
                .HasForeignKey(e => e.IdTransporte)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Ubicacion>()
                .Property(e => e.Ubicacion1)
                .IsUnicode(false);

            modelBuilder.Entity<Ubicacion>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Ubicacion>()
                .Property(e => e.Latitud)
                .IsUnicode(false);

            modelBuilder.Entity<Ubicacion>()
                .Property(e => e.Longitud)
                .IsUnicode(false);
        }
    }
}
