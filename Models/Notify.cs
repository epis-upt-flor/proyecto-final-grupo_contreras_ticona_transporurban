using System;

namespace Project.Models
{
    public class Notify
    {
        public int Id { get; set; }

        public int? IdUsuario { get; set; }

        public string Descripcion { get; set; }

        public string Direccion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public DateTime? Fecha { get; set; }
    }
}