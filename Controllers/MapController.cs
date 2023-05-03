using Project.DTO;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

    }
}