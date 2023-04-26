namespace Project.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usuario")]
    public partial class usuario
    {
        public int id { get; set; }

        public int? idTipoUsuario { get; set; }

        [StringLength(100)]
        public string nombreCompleto { get; set; }

        [Column("usuario")]
        [StringLength(100)]
        public string usuario1 { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        public byte? estado { get; set; }
    }
}
