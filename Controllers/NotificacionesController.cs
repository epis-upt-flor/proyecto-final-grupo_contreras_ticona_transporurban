using Newtonsoft.Json;
using Project.DTO;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class NotificacionesController : Controller
    {
        private ModelMap db = new ModelMap();
        // GET: Notificaciones
        public ActionResult Index()
        {
            //ViewBag.Usuario = db.Usuarios.Find(2);
            return View(/*db.Notificacion.ToList()*/);
        }
        [HttpGet]
        public ActionResult ListarNotificacionJson()
        {
            string mensaje = "";
            var data = new List<Notificacion>();
            var resultado = string.Empty;
            var user = (Usuario)Session["UsuarioFull"];
            try
            {
                if (user.idTipoUsuario == 3)
                {
                    var query = from a in db.Notificacion
                                join b in db.Usuarios on a.IdUsuario equals b.Id
                                select new
                                {
                                    Notifiacion = new Notify
                                    {
                                        Id = a.Id,
                                        IdUsuario = a.IdUsuario,
                                        Descripcion = a.Descripcion,
                                        Direccion = a.Direccion,
                                        Fecha = a.Fecha,
                                        Latitud = a.Latitud,
                                        Longitud = a.Longitud,
                                    },
                                    Usuarios = new User
                                    {
                                        Usuario = b.usuario
                                    }
                                };
                    resultado = JsonConvert.SerializeObject(query);
                }
                else
                {
                    var query = from a in db.Notificacion
                                join b in db.Usuarios on a.IdUsuario equals b.Id
                                where a.IdUsuario== user.id
                                select new
                                {
                                    Notifiacion = new Notify
                                    {
                                        Id = a.Id,
                                        IdUsuario = a.IdUsuario,
                                        Descripcion = a.Descripcion,
                                        Direccion = a.Direccion,
                                        Fecha = a.Fecha,
                                        Latitud = a.Latitud,
                                        Longitud = a.Longitud,
                                    },
                                    Usuarios = new User
                                    {
                                        Usuario = b.usuario
                                    }
                                };
                    resultado = JsonConvert.SerializeObject(query);
                }
                

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return Json(new { resultado, mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdUsuario,Direccion,Descripcion,Latitud,Longitud")] Notificacion notificacion)
        {
            if (notificacion.Id == 0)
            {
                //notificacion.IdUsuario = Convert.ToInt32(Request["IdUsuario"]);
                //notificacion.Direccion = Request["Direccion"];
                //notificacion.Descripcion = Request["Descripcion"];
                //notificacion.Latitud = Request["Latitud"];
                //notificacion.Longitud = Request["Longitud"];
                notificacion.Fecha = DateTime.Now;
                db.Notificacion.Add(notificacion);
                db.SaveChanges();
                //return RedirectToAction("Index", "Clientes");
                return RedirectToAction("Index");
            }else
            {
                if (ModelState.IsValid)
                {
                    notificacion.Fecha = DateTime.Now;
                    db.Entry(notificacion).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                //return RedirectToAction("Index", "Clientes");
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.Usuarios, "Id", "usuario", notificacion.IdUsuario);
            return View(notificacion);
        }
        [HttpPost]
        public ActionResult EliminarNotificacionId(int id)
        {
            var dato = db.Notificacion.Find(id);
            if (dato == null )
            {
                return HttpNotFound();
            }
            db.Notificacion.Remove(dato);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ObtenerNotificacionId( int id)
        {
            string mensaje = "";
            var data = new Notificacion();
            var resultado = string.Empty;
            try
            {
                var query = (from a in db.Notificacion
                            join b in db.Usuarios on a.IdUsuario equals b.Id
                            where a.Id == id
                            select new
                            {
                                Notifiacion = new Notify
                                {
                                    Id = a.Id,
                                    IdUsuario = a.IdUsuario,
                                    Descripcion = a.Descripcion,
                                    Direccion = a.Direccion,
                                    Fecha = a.Fecha,
                                    Latitud = a.Latitud,
                                    Longitud = a.Longitud,
                                },
                                Usuarios = new User
                                {
                                    Usuario = b.usuario
                                }
                            }).FirstOrDefault();
                resultado = JsonConvert.SerializeObject(query);

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return Json(new { resultado, mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}