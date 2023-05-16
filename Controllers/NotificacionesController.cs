using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class NotificacionesController : Controller
    {
        private ModelMap db = new ModelMap();
        // GET: Notificaciones
        public ActionResult Index()
        {
            ViewBag.Usuario = db.Usuarios.Find(2);
            return View();
        }
    }
}