using ConectionApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace CrecosaWebApi.Controllers
{
    public class crm_SolicitudController : Controller
    {   
        [HttpPost]
        public ActionResult Index(string idcredito)
        {
           
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            DateTime fecActual = DateTime.Now;
            DateTime fecFutura = DateTime.Now;
            int k = 0;

            for (int i=0; i<7; i++)
            {
                k = k + 1;
                fecFutura = fecActual.AddDays(k);
                if (fecFutura.DayOfWeek == DayOfWeek.Sunday)
                {
                    k = k + 1;
                }
              
            }

            Cliente cliente = new Cliente();
            cliente = cliente.GetIdClientesMicrofin(idcredito);
            ViewBag.cliente = cliente;
            ViewBag.fecFutura = fecFutura.ToString();
            ViewBag.Title = "Solicitud de reclamo Credito: " + idcredito.ToString();
            return View();
        }

        public ActionResult FindClient()
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}


            Cliente cliente = new Cliente();
            List<Cliente> listclientes = new List<Cliente>();
            ViewBag.listclientes = listclientes;
            ViewBag.Title = "Buscando Clientes Microfin";
            return View();

        }

        [HttpPost]
        public ActionResult FindClient(string buscar)
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            
            Cliente cliente = new Cliente();
            List<Cliente> listclientes = cliente.GetFilterClientesMicrofin(buscar.ToString());
            ViewBag.listclientes = listclientes;
            ViewBag.Title = "Filtrado Cliente";
            return View();

        }

        [HttpPost]
        public ActionResult Confirmar(FormCollection myform)
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            ViewBag.myform = myform;
            ViewBag.Title = "Confirmar Datos del Cliente";
            return View();

        }

        public ActionResult ViewEvaluacion()
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            Solicitud solicitud = new Solicitud();
            List<Solicitud> listsolicitud = solicitud.View("E");
            ViewBag.listsolicitud = listsolicitud;
            ViewBag.Title = "Ver Solicitudes en Evaluacion";
            return View();

        }

        [HttpPost]
        public ActionResult ViewEvaluacion(string buscar)
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            Solicitud solicitud = new Solicitud();
            List<Solicitud> listsolicitud = solicitud.View("E", buscar);
            ViewBag.listsolicitud = listsolicitud;
            ViewBag.Title = "Ver Solicitudes en Evaluacion";
            return View();

        }

        [HttpPost]
        public ActionResult NextStatus(FormCollection myform)
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            Solicitud solicitud = new Solicitud();
            solicitud.codigounico = long.Parse(myform["codigounico"].ToString());
            solicitud.cliente = myform["cliente"].ToString();
            solicitud.solicita = myform["solicita"].ToString();
            solicitud.fechavence = DateTime.Parse( myform["fechavence"].ToString());
            solicitud.status = myform["status"].ToString();
            string viewstatus;

            if (myform["view"].ToString().Equals("query"))
            {
                 viewstatus = "Q";
            }
            else
            {
                viewstatus = solicitud.status;
            }

            List<Tracking> listtracking = new List<Tracking>();
            Tracking tracking = new Tracking();
            listtracking = tracking.View(solicitud.codigounico);

            ViewBag.solicitud = solicitud;
            ViewBag.listtracking = listtracking;
            ViewBag.viewstatus = viewstatus;

            ViewBag.Title = "Siguimiento de Casos";
            return View();

        }

        [HttpPost]
        public ActionResult GuardarNextStatus(FormCollection myform)
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            Tracking tracking = new Tracking();
            tracking.codigounico = long.Parse(myform["codigounico"].ToString());
            tracking.cliente = myform["cliente"].ToString();
            tracking.solicita = myform["solicita"].ToString();
            tracking.fechavence = DateTime.Parse(myform["fechavence"].ToString());
            tracking.status = myform["status"].ToString();
            tracking.dstracking = myform["dstracking"].ToString();
            
            switch (myform["newstatus"].ToString())
            {
                case "Evaluacion":
                    tracking.newstatus = "E";
                    break;
                case "Comite":
                    tracking.newstatus = "C";
                    break;
                case "Notificar":
                    tracking.newstatus = "N";
                    break;
                case "Cerrar":
                    tracking.newstatus = "X";
                    break;
            }
            tracking.fechatracking =  DateTime.Now;

           tracking.Insert(tracking);
           return RedirectToAction("Index", "crm_menu");

        }

        public ActionResult FAQ()
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            ViewBag.Title = "Frecuently Asked Questions (FAQ)";
            return View();

        }

        public ActionResult ViewComite()
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            Solicitud solicitud = new Solicitud();
            List<Solicitud> listsolicitud = solicitud.View("C");
            ViewBag.listsolicitud = listsolicitud;
            ViewBag.Title = "Analisis por parte del comite";
            return View();

        }

        [HttpPost]
        public ActionResult ViewComite(string buscar)
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            Solicitud solicitud = new Solicitud();
            List<Solicitud> listsolicitud = solicitud.View("C", buscar);
            ViewBag.listsolicitud = listsolicitud;
            ViewBag.Title = "Analisis por parte del comite";
            return View();

        }

        public ActionResult ViewNotificar()
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            Solicitud solicitud = new Solicitud();
            List<Solicitud> listsolicitud = solicitud.View("N");
            ViewBag.listsolicitud = listsolicitud;
            ViewBag.Title = "Lista de reclamos en notificacion";
            return View();

        }

        [HttpPost]
        public ActionResult ViewNotificar(string buscar)
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            Solicitud solicitud = new Solicitud();
            List<Solicitud> listsolicitud = solicitud.View("N", buscar);
            ViewBag.listsolicitud = listsolicitud;
            ViewBag.Title = "Lista de reclamos en notificacion";
            return View();

        }

        public ActionResult ViewCerrados()
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            Solicitud solicitud = new Solicitud();
            List<Solicitud> listsolicitud = solicitud.View("X");
            ViewBag.listsolicitud = listsolicitud;
            ViewBag.Title = "Listado de Casos Cerrados";
            return View();

        }

        [HttpPost]
        public ActionResult ViewCerrados(string buscar)
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            Solicitud solicitud = new Solicitud();
            List<Solicitud> listsolicitud = solicitud.View("X", buscar);
            ViewBag.listsolicitud = listsolicitud;
            ViewBag.Title = "Buscar en los Casos Cerrados";
            return View();

        }

        public ActionResult ViewConsulta()
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
            ViewBag.Title = "Consulta de Casos";
            return View();

        }

        [HttpPost]
        public ActionResult ViewConsulta(string buscar)
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
            ViewBag.Title = "Consulta de Casos";
            return View();

        }

        
    }
}
