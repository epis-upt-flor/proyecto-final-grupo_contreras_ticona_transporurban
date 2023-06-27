using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class LatLng
    {
        public LatLng() { } 
        public LatLng(double Lat, double Lng) 
        {
            Latitude = Lat;
            Longitude = Lng;
        } 

        public string Ubicacion { get; set; }
        public string Inicio { get; set; }
        public string Destino { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string mensaje { get; set; }
        public bool estado { get; set; }
    }
}