using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class UbicacionViewModel
    {
        public int Id { get; set; }
        public int? IdTransporte { get; set; }
        public string Ubicacion { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
    }
}