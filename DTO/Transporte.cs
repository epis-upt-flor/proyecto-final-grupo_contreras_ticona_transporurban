namespace Project.DTO
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Transporte")]
    public partial class Transporte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transporte()
        {
            Ubicacion = new HashSet<Ubicacion>();
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [StringLength(500)]
        public string Latitud { get; set; }

        [StringLength(500)]
        public string Longitud { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Ubicacion> Ubicacion { get; set; }
    }
}
