using Project.DTO;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Mvc;


namespace Project.Controllers
{
    public class MapController : Controller
    {

        private ModelMap db = new ModelMap();
        // GET: Map
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddRutas(int? id)
        {

            var ubicacion = db.Ubicacion.Include(u => u.Transporte);
            if (ubicacion == null)
            {
                ViewBag.Transportes = db.Transporte.ToList();
                return View(ubicacion.ToList());
            }
            else
            {
                ViewBag.Transportes = db.Transporte.ToList();
                ViewBag.Transporte = db.Transporte.Find(1);
                return View(ubicacion.ToList());
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdTransporte,Ubicacion1,Descripcion,Latitud,Longitud")] Ubicacion ubicacion)
        {
            if (ubicacion.Ubicacion1 != string.Empty)
            {
                db.Ubicacion.Add(ubicacion);
                db.SaveChanges();
                return RedirectToAction("AddRutas");
            }

            ViewBag.IdTransporte = new SelectList(db.Transporte, "Id", "Nombre", ubicacion.IdTransporte);
            return View(ubicacion);
        }
        // GET: Ubicacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubicacion ubicacion = db.Ubicacion.Find(id);
            if (ubicacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTransporte = new SelectList(db.Transporte, "Id", "Nombre", ubicacion.IdTransporte);
            return View(ubicacion);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdTransporte,Ubicacion1,Descripcion,Latitud,Longitud")] Ubicacion ubicacion)
        {
            if (ubicacion.Ubicacion1 != string.Empty)
            {
                db.Entry(ubicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AddRutas");
            }
            ViewBag.IdTransporte = new SelectList(db.Transporte, "Id", "Nombre", ubicacion.IdTransporte);
            return View(ubicacion);
        }

        //Solo pruebas
        public ActionResult About()
        {
            ViewBag.Transportes = db.Transporte.Find(1);
            return View();
        }
        [HttpPost]
        public JsonResult CreateTransporte(string latitud, string longitud, string descripcion, string name)
        {
            bool estado = false;

            try
            {
                estado = true;
                Transporte transporte = new Transporte();
                transporte.Nombre = descripcion;
                transporte.Descripcion = descripcion;
                transporte.Latitud = latitud;
                transporte.Longitud = longitud;

                if (!db.Transporte.Any())
                {
                    db.Transporte.Add(transporte);
                    db.SaveChanges();
                }
                var existe = db.Transporte.Where(x => x.Latitud == latitud && x.Longitud == longitud).FirstOrDefault();
                if (existe != null)
                {
                    return new JsonResult { Data = new { estado = estado } };
                }
                else
                {
                    db.Transporte.Add(transporte);
                    db.SaveChanges();
                }
                return new JsonResult { Data = new { estado = estado } };
            }
            catch (Exception ex)
            {
                estado = false;
            }

            return new JsonResult { Data = new { estado = estado } };
        }
        [HttpGet]
        public ActionResult Rutas()
        {
            ViewBag.Transportes = db.Transporte.Find(1);
            return View();
        }
        public ActionResult ListaRutas()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var rutas = db.Ubicacion.ToList();
            return Json(rutas, JsonRequestBehavior.AllowGet);
            //return new JsonResult { Data = rutas, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Polilines()
        {
            var ubicacion = db.Ubicacion.Include(u => u.Transporte);
            if (ubicacion == null)
            {
                ViewBag.Transportes = db.Transporte.ToList();
                return View(ubicacion.ToList());
            }
            else
            {
                ViewBag.Transportes = db.Transporte.ToList();
                ViewBag.Transporte = db.Transporte.Find(1);
                return View(ubicacion.ToList());
            }
        }

        public ActionResult RutasCerca(string Destino, string Latitud, string Longitud, string Inicio, string InicioLat, string InicioLng)
        {
            string encodePolyline = "ho|lBnctkLMWSYUYMWMWU_@QSIOMQQYIKW_@UYOQGMOUQ[QUKQOWU]QYMSSYS_@OWQYS[MS[i@Sg@g@o@w@}Aq@cA_A{Au@eAo@wAm@{@WU[PSLc@\\a@Xg@^c@^m@f@c@\\m@b@o@h@m@^k@b@s@f@o@j@m@j@e@^a@^o@j@s@l@a@^OLGCK_@";
            List<LatLng> polylines = new List<LatLng>();
            LatLng PosicionActual = new LatLng();
            LatLng Final = new LatLng();
            PosicionActual.Latitude = Convert.ToDouble(InicioLat);
            PosicionActual.Longitude = Convert.ToDouble(InicioLng);
            //PosicionActual.Latitude = -18.00688;
            //PosicionActual.Longitude = -70.22784;

            // -18.0021259,-70.2259489 - 18.0048472,-70.2286921
            Final.Latitude = Convert.ToDouble(Latitud);
            Final.Longitude = Convert.ToDouble(Longitud);
            db.Configuration.ProxyCreationEnabled = false;
            var rutas = db.Ubicacion.ToList();
            //foreach (var rut in rutas)
            //{
            //    LatLng point = new LatLng();
            //    point.Ubicacion = rut.Ubicacion1;
            //    point.Latitude = Convert.ToDouble(rut.Latitud);
            //    point.Longitude = Convert.ToDouble(rut.Longitud);
            //    polylines.Add(point);
            //}
            polylines = DecodePolyline(encodePolyline);
            int resultadosdebusqueda = 0;
            foreach (var objbut in polylines)
            {
                bool condicionInicio = false;
                bool condicionFinal = false;
                LatLng point = new LatLng();
                point.Latitude = objbut.Latitude;
                point.Longitude = objbut.Longitude;
                if (resultadosdebusqueda == 0)
                {
                    condicionInicio = consultaPuntoCerca(0.00180, point, PosicionActual); //donde me encuentro
                    condicionFinal = consultaPuntoCerca(0.00180, point, Final); //donde quiero ir
                }

                if (condicionFinal && condicionInicio)
                {
                    resultadosdebusqueda++;
                    return Json(new { estado = true, mensaje = "Encontro ruta para su destino", data = polylines, JsonRequestBehavior.AllowGet });
                }
            }

            //return Json(rutas, JsonRequestBehavior.AllowGet);
            return Json(new { estado = true, mensaje = "No encontro ruta para su destino", data = polylines, JsonRequestBehavior.AllowGet });
        }
        private bool consultaPuntoCerca(double cercania, LatLng pruta, LatLng prutaconsulta)
        {
            double longitud = pruta.Longitude - (prutaconsulta.Longitude);
            double latitud = pruta.Latitude - (prutaconsulta.Latitude);

            double resultadomodulo = Math.Sqrt(longitud * longitud + latitud * latitud);

            if (cercania > resultadomodulo) return true;
            return false;

        }



        public ActionResult Action()
        {
            List<LatLng> polylines = new List<LatLng>();
            //codificar rutas de latitudes y longitudes utilizando la codificación Polyline de Google Maps
            string encode = EncodePolyline(polylines);
            //decodifica un string codificado de Google Maps Polylines
            polylines = DecodePolyline(encode);
            return View();
        }
        public string EncodePolyline(List<LatLng> polyline)
        {
            StringBuilder encoded = new StringBuilder();
            int prevLat = 0;
            int prevLng = 0;

            foreach (LatLng point in polyline)
            {
                int lat = (int)(point.Latitude * 1E5);
                int lng = (int)(point.Longitude * 1E5);

                int dLat = lat - prevLat;
                int dLng = lng - prevLng;

                prevLat = lat;
                prevLng = lng;

                encoded.Append(EncodeValue(dLat));
                encoded.Append(EncodeValue(dLng));
            }

            return encoded.ToString();
        }

        private string EncodeValue(int value)
        {
            StringBuilder encodedValue = new StringBuilder();

            value = value < 0 ? ~(value << 1) : (value << 1);

            while (value >= 0x20)
            {
                int nextValue = (0x20 | (value & 0x1F)) + 63;
                encodedValue.Append((char)nextValue);
                value >>= 5;
            }

            encodedValue.Append((char)(value + 63));

            return encodedValue.ToString();
        }

        public List<LatLng> DecodePolyline(string encodedPolyline)
        {
            List<LatLng> polyline = new List<LatLng>();
            int index = 0;
            int latitude = 0;
            int longitude = 0;

            while (index < encodedPolyline.Length)
            {
                int shift = 0;
                int result = 0;

                while (true)
                {
                    int b = encodedPolyline[index] - 63;
                    index++;
                    result |= (b & 0x1F) << shift;
                    shift += 5;

                    if (b < 0x20)
                        break;
                }

                int dlat = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
                latitude += dlat;

                shift = 0;
                result = 0;

                while (true)
                {
                    int b = encodedPolyline[index] - 63;
                    index++;
                    result |= (b & 0x1F) << shift;
                    shift += 5;

                    if (b < 0x20)
                        break;
                }

                int dlng = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
                longitude += dlng;

                LatLng point = new LatLng(latitude * 1E-5, longitude * 1E-5);
                polyline.Add(point);
            }

            return polyline;
        }

    }
}