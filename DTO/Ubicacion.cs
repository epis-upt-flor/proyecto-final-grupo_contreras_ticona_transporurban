namespace Project.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ubicacion")]
    public partial class Ubicacion
    {
        public int Id { get; set; }
        [Display(Name = "Linea")]

        public int? IdTransporte { get; set; }

        [Column("Ubicacion")]
        public string Ubicacion1 { get; set; }

        public string Descripcion { get; set; }

        [StringLength(500)]
        public string Latitud { get; set; }

        [StringLength(500)]
        public string Longitud { get; set; }

        public virtual Transporte Transporte { get; set; }
    }
}
