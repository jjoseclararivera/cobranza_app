using ConectionApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrecosaAppCrm.Controllers
{
    public class crm_menuController : Controller
    {
        
        public ActionResult Index()
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            Solicitud solicitud = new Solicitud();
            List<Solicitud> listsolicitud = solicitud.View("A");
            ViewBag.listsolicitud = listsolicitud;
            ViewBag.Title = "Atender";
           
            return View();

        }

        
        [HttpPost]
        public ActionResult Index(string buscar)
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            Solicitud solicitud = new Solicitud();
            List<Solicitud> listsolicitud = solicitud.View("A", buscar);
            ViewBag.listsolicitud = listsolicitud;
            ViewBag.Title = "Atender";
            return View();

        }
    }
}