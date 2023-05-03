namespace Project.DTO
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ubicacion")]
    public partial class Ubicacion
    {

        public int Id { get; set; }

        public int? IdTransporte { get; set; }

        [Column("Ubicacion")]
        public string Ubicacion1 { get; set; }

        public string Descripcion { get; set; }

        [StringLength(500)]
        public string Latitud { get; set; }

        [StringLength(500)]
        public string Longitud { get; set; }
        [JsonIgnore]
        public virtual Transporte Transporte { get; set; }
    }
}
