using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Project.DTO
{
    public partial class ModelRutas : DbContext
    {
        public ModelRutas()
            : base("name=ModelRutas")
        {
        }

        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ubicacion>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Ubicacion>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Ubicacion>()
                .Property(e => e.Latitud)
                .IsUnicode(false);

            modelBuilder.Entity<Ubicacion>()
                .Property(e => e.Longitud)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.nombreCompleto)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.usuario1)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
