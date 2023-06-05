namespace Project.Data
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Notificacion")]
    public partial class Notificacion
    {
        public int Id { get; set; }

        public int? IdUsuario { get; set; }

        public string Descripcion { get; set; }

        public string Direccion { get; set; }

        [StringLength(500)]
        public string Latitud { get; set; }

        [StringLength(500)]
        public string Longitud { get; set; }

        public DateTime? Fecha { get; set; }

        [JsonIgnore]
        public virtual Usuarios Usuarios { get; set; }
    }
}
