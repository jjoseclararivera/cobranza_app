using ConectionApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrecosaWebApi.Controllers
{
    public class crm_NumeroCasoController : Controller
    {
        
        public ActionResult Index(FormCollection forminput)
        {
            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = (Usuario)Session["usuario"];
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return RedirectToAction("Index", "Home");
            //}

            Solicitud solicitud = new Solicitud();
            Dictionary<string, string> formdata = new Dictionary<string, string>();
            foreach (var key in forminput.Keys)
            {
                var value = forminput[key.ToString()];
                formdata.Add(key.ToString(), value);
                
            }
            long num = solicitud.Insert(formdata);
            ViewBag.Title = "Numero de Caso";
            ViewBag.NumeroCaso = num;
            return View();
        }
    }
}