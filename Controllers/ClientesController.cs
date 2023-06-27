using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ClientesController : Controller
    {
        private ModelMap db = new ModelMap();
        // GET: Clientes
        public ActionResult Index()
        {
            ViewBag.Transportes = db.Transporte.Find(1);
            return View();
        }
        public ActionResult ListaRutas()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var rutas = db.Ubicacion.ToList();
            return Json(rutas, JsonRequestBehavior.AllowGet);
        }
        public ActionResult listTransports()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var transports = db.Transporte.ToList();
            return Json(transports, JsonRequestBehavior.AllowGet);
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
    }
}