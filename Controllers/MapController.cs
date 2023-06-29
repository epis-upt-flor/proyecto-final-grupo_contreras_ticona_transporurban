using Project.DTO;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            ViewBag.Transportes = db.Transporte.Find(1);
            return View();
        }
        [HttpGet]
        public ActionResult AddRutas(int? id)
        {

            var ubicacion = db.Ubicacion.Where(x => x.IdTransporte == id).ToList();
            //if (ubicacion.Count == 0)
            //{
                //ViewBag.Transportes = db.Transporte.ToList();
                ViewBag.Transporte = db.Transporte.Find(id);
                return View(ubicacion);
            //}
            //else
            //{
            //    ViewBag.Transportes = db.Transporte.ToList();
            //    ViewBag.Transporte = db.Transporte.Find(id);
            //    return View(ubicacion);
            //}

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdTransporte,Ubicacion1,Descripcion,Latitud,Longitud")] Ubicacion ubicacion)
        {
            int? id = ubicacion.IdTransporte;
            if (ubicacion.Ubicacion1 != string.Empty)
            {
                db.Ubicacion.Add(ubicacion);
                db.SaveChanges();
                return RedirectToAction("AddRutas",new { id = id });
            }

            //ViewBag.IdTransporte = new SelectList(db.Transporte, "Id", "Nombre", ubicacion.IdTransporte);
            ViewBag.Transporte = db.Transporte.Find(ubicacion.IdTransporte);
            var ubicaciones = db.Ubicacion.Where(x => x.IdTransporte == ubicacion.IdTransporte).ToList();
            return RedirectToAction("AddRutas",ubicaciones);
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
        public JsonResult CreateTransporte(Transporte transporte)
        {
            bool estado = false;

            try
            {
                if (!db.Transporte.Any())
                {
                    db.Transporte.Add(transporte);
                    db.SaveChanges();
                }
                var existe = db.Transporte.Where(x => x.Latitud == transporte.Latitud && x.Longitud == transporte.Longitud).FirstOrDefault();
                if (existe != null)
                {
                    return new JsonResult { Data = new { estado = estado } };
                }
                else
                {
                    db.Transporte.Add(transporte);
                    db.SaveChanges();
                    estado = true;
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
        public ActionResult listTransports()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var transports = db.Transporte.ToList();
            return Json(transports, JsonRequestBehavior.AllowGet);
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
            //string encodePolyline = "bpbmB~zxkL?I?G?G?I?G?G@K?I?I?G?G?I?G@K?I?G?I@K?M?I?M@O?M?K?M?I?K@I?I?K?I?I?K@M@M@M?K@K@M@MAM?M?KAK?K?G?K?I?O@Q?S@Q@Q?O?Q@U?Q?S?Q@S?O?M?Q?S?U?Q@S?EIAM?KAM?OAM?MAM?M?OAM?MAM?KAIAI?K?K?K?I?M?KAK?K?M?K?M?MAK?K?K?KAI?K?KAK?K?I?IAI?I?K?IAG?I?I?I?K?K?K?I?I?MAM@M?M?IAK?KAI?K?KAK?K?IAK?M?KAK?K?M?KAK?I?K?KAK?I?I?K?KAI?I?K?I?I?I?I?I?ICIAI?G?K?K?KAK?M?MAK?O?OAO?M?OAO?M?MAK?K?M?KAK?K?K?IAM?I?KAMCMCGAI?K?K?KAO?Q?QAI?K?MAM@M?O?M@M?IAM?M?K?I?KAKAKAKAMAMAMAK?K?K?I?I?K?I?IAK?M?O?O?OAK?M?M?MAK?O?OAM?O?OAM?M?O?QAO?QAQ?S?OAM?Q?QAO?O?Q?U?S?S?K?GAICECIIGKEIGEKIKEMCOAMAI@K@IBIDGDEDEFEHEHEBGBGDIBGDIBKFGBIBIBO?K@I@I?K@I?K@K@K?OBK?K@KBM@I@G@G@GBK@KBKBMBKBKBMBGBGBIDIDKDGBKFIBIBODODODODKBMBMBMDI@MDMBMBKBMDKBKBK@KBKBMBKBKBK@KBI@IBMBKBI@GBIDGBIDG@GDIBKBKBI@KBIBK@MBKBK@IBK@OBMBKBIBIBIBKBIBIBIBKBIBIBG@GBI@G@G@IBI@KBI@K@KBI@I@G@KBK?M@I@K@K?I@M?M@M@M?K@M?K?M@M?K@K@K?M@M?M@M?O@M?M@K?K@I?M?M@K?M?M@M?I?M@K?M@M?M?K@Q?K@M?K?I@K?I?M@M?K@K?K?M@K?M?M@K?E?EIIWG_@Gc@G]G[G]ESOWKUMUKSQWGKMQMMIKOOKKMOQUMQKMMQKOKOMOMQMQKOIKIMOQMQKMKMIMIKGKIKKMIKKMIMKMIIKMMQKMIKKMGIKOKMIKGIIIGKIKGIIMKKIMIKIMIKIKIMIKIMKOIKIKGKIMKMIMKOMOIMIKGIIKIMKMGIGKIKIKGIIKIMIKGIEIGIIKGIGKIKIMIKGIGKGGGKGGGKIMIKEGIFGDGFEBGDIDGDGDIDGDIDGBGBIDKDIDIBGBIDGBG@G?EBGBGDGBGDKDKFGDIBIDKFIDIDKDIDKFIDIDIDGBIDMDMFKDIBIDIDMDMFMDOHMDKDKDIDGBIDIDIDIDIFKFIDMFMHIDKFKFIDIFIDIDEBCBEGIMGKGGGIIGGOKQGQGOGOEQEQGOHGHK@Q?MAMEIEGEGAUCQAQCQCSEUCUEOCMCMAQCO?OAQAUAMCOEUCQESCQCQAOCQCOCKAOCQEUCUEWCYCQESCUCUCOE]G_@I]KYI[IQKWKSMUMWOYKSKQKQIMMSKMKOMUIMS[MSKOIMEGKHKHMJHLHLFJHLHJHJHLHJHPDJFNDLFPFPDLFPDLBFGDGFEDIFGFMJIHIHGDGFIHKHGFKHIHIHGFKHIFKJIFKJMJIHKJIFIFKJIFKHKHIHIFIHKHKHIFIFIHKHGFEBGFIFIHGDEDGDGFGFGDGFGFGFGDGFGDGDGFGDIFIFGDGDIDIFGDGDEDGBIDIFKFKDIDIFIBIBKDKBIBIDGBKBIBKBIBIBKBI@GBGBI@IBG@G@I@G@I@I@K@G?G@I?IAI?K?M?K?K?K?M?K?G?KAMAI?K?K?K?K?I?K?K?K?K?K?M?I?K?K?K@I?I?G?K?I?I?K@M?K?K?I?G?I?I?I@K?I?E?ICIEG?M?Q?K?O?M?O?O?O?O?Q?O?O?Q?O?Q?O?M?M?M?M?O?O?O?O?O?O?O?M?M?Q?M?I?M?M?I?O?M?M?K?G?K?I?C??HAJ?F?H?H?N?T?J?L?N?L?LAN?L?L?L?L?N?N?N?L?L?N?L?P?P?R?P?R?R?L?L?N?P?R?PAN?R?L?P?L?JAH?H@J?J?L?L?P?H@P?N?R?L?N?J?L?L?J?J?J?J?J?L@JAJ@LAL@J?L?L?J?H?J?L?L?J?N?L?L?N?L?N@J?L@J@L@N@LBL@L@HBL@L@LBL@LBN@JG?I?I?K?I?I?I?I?G?K?I?I?G?@H?L?FH?F?H?DAF@FAF?H?F?H?F?H?F?H?D?";
            //string encodePolyline = "bpbmB~zxkL?I?G?G?I?G?G@K?I?I?G?G?I?G@K?I?G?I@K?M?I?M@O?M?K?M?I?K@I?I?K?I?I?K@M@M@M?K@K@M@MAM?M?KAK?K?G?K?I?O@Q?S@Q@Q?O?Q@U?Q?S?Q@S?O?M?Q?S?U?Q@S?EIAM?KAM?OAM?MAM?M?OAM?MAM?KAIAI?K?K?K?I?M?KAK?K?M?K?M?MAK?K?K?KAI?K?KAK?K?I?IAI?I?K?IAG?I?I?I?K?K?K?I?I?MAM@M?M?IAK?KAI?K?KAK?K?IAK?M?KAK?K?M?KAK?I?K?KAK?I?I?K?KAI?I?K?I?I?I?I?I?ICIAI?G?K?K?KAK?M?MAK?O?OAO?M?OAO?M?MAK?K?M?KAK?K?K?IAM?I?KAMCMCGAI?K?K?KAO?Q?QAI?K?MAM@M?O?M@M?IAM?M?K?I?KAKAKAKAMAMAMAK?K?K?I?I?K?I?IAK?M?O?O?OAK?M?M?MAK?O?OAM?O?OAM?M?O?QAO?QAQ?S?OAM?Q?QAO?O?Q?U?S?S?K?GAICECIIGKEIGEKIKEMCOAMAI@K@IBIDGDEDEFEHEHEBGBGDIBGDIBKFGBIBIBO?K@I@I?K@I?K@K@K?OBK?K@KBM@I@G@G@GBK@KBKBMBKBKBMBGBGBIDIDKDGBKFIBIBODODODODKBMBMBMDI@MDMBMBKBMDKBKBK@KBKBMBKBKBK@KBI@IBMBKBI@GBIDGBIDG@GDIBKBKBI@KBIBK@MBKBK@IBK@OBMBKBIBIBIBKBIBIBIBKBIBIBG@GBI@G@G@IBI@KBI@K@KBI@I@G@KBK?M@I@K@K?I@M?M@M@M?K@M?K?M@M?K@K@K?M@M?M@M?O@M?M@K?K@I?M?M@K?M?M@M?I?M@K?M@M?M?K@Q?K@M?K?I@K?I?M@M?K@K?K?M@K?M?M@K?E?EIIWG_@Gc@G]G[G]ESOWKUMUKSQWGKMQMMIKOOKKMOQUMQKMMQKOKOMOMQMQKOIKIMOQMQKMKMIMIKGKIKKMIKKMIMKMIIKMMQKMIKKMGIKOKMIKGIIIGKIKGIIMKKIMIKIMIKIKIMIKIMKOIKIKGKIMKMIMKOMOIMIKGIIKIMKMGIGKIKIKGIIKIMIKGIEIGIIKGIGKIKIMIKGIGKGGGKGGGKIMIKEGIFGDGFEBGDIDGDGDIDGDIDGBGBIDKDIDIBGBIDGBG@G?EBGBGDGBGDKDKFGDIBIDKFIDIDKDIDKFIDIDIDGBIDMDMFKDIBIDIDMDMFMDOHMDKDKDIDGBIDIDIDIDIFKFIDMFMHIDKFKFIDIFIDIDEBCBEGIMGKGGGIIGGOKQGQGOGOEQEQGOHGHK@Q?MAMEIEGEGAUCQAQCQCSEUCUEOCMCMAQCO?OAQAUAMCOEUCQESCQCQAOCQCOCKAOCQEUCUEWCYCQESCUCUCOE]G_@I]KYI[IQKWKSMUMWOYKSKQKQIMMSKMKOMUIMS[MSKOIMEGKHKHMJHLHLFJHLHJHJHLHJHPDJFNDLFPFPDLFPDLBFGDGFEDIFGFMJIHIHGDGFIHKHGFKHIHIHGFKHIFKJIFKJMJIHKJIFIFKJIFKHKHIHIFIHKHKHIFIFIHKHGFEBGFIFIHGDEDGDGFGFGDGFGFGFGDGFGDGDGFGDIFIFGDGDIDIFGDGDEDGBIDIFKFKDIDIFIBIBKDKBIBIDGBKBIBKBIBIBKBI@GBGBI@IBG@G@I@G@I@I@K@G?G@I?IAI?K?M?K?K?K?M?K?G?KAMAI?K?K?K?K?I?K?K?K?K?K?M?I?K?K?K@I?I?G?K?I?I?K@M?K?K?I?G?I?I?I@K?I?E?ICIEG?M?Q?K?O?M?O?O?O?O?Q?O?O?Q?O?Q?O?M?M?M?M?O?O?O?O?O?O?O?M?M?Q?M?I?M?M?I?O?M?M?K?G?K?I?C??HAJ?F?H?H?N?T?J?L?N?L?LAN?L?L?L?L?N?N?N?L?L?N?L?P?P?R?P?R?R?L?L?N?P?R?PAN?R?L?P?L?JAH?H@J?J?L?L?P?H@P?N?R?L?N?J?L?L?J?J?J?J?J?L@JAJ@LAL@J?L?L?J?H?J?L?L?J?N?L?L?N?L?N@J?L@J@L@N@LBL@L@HBL@L@LBL@LBN@JG?I?I?K?I?I?I?I?G?K?I?I?G?@H?L?FH?F?H?DAF@FAF?H?F?H?F?H?F?H?D?";
            List<LatLng> polylines = new List<LatLng>();
            LatLng PosicionActual = new LatLng();
            LatLng Final = new LatLng();
            //PosicionActual.Latitude = Convert.ToDouble(InicioLat);
            //PosicionActual.Longitude = Convert.ToDouble(InicioLng);
            PosicionActual.Latitude = -18.00688;
            PosicionActual.Longitude = -70.22784;

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
            return Json(new { estado = true, mensaje = "No encontro ruta para su destino", rutas = polylines, JsonRequestBehavior.AllowGet });
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