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

        public int? IdRutas { get; set; }

        public string Descripcion { get; set; }

        public string Titulo { get; set; }

        [StringLength(500)]
        public string Latitud { get; set; }

        [StringLength(500)]
        public string Longitud { get; set; }
    }
}
