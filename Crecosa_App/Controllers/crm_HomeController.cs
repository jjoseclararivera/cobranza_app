using ConectionApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CrecosaWebApi.Controllers
{
    public class crm_HomeController : Controller
    {
       
        [HttpPost]
        public ActionResult Index(FormCollection usuario)
        {
            //ViewBag.Error = "Login o password no pueden estar vacíos";

            //if (string.IsNullOrEmpty(usuario.ID_USUARIO) ||
            //string.IsNullOrEmpty(usuario.CLAVE))
            //{
            //    ViewBag.Error = "Login o password no pueden estar vacíos";
            //    return View(usuario);
            //}
            // Damos de alta el usuario en la BBDD y redireccionamos
            Session["usuario"] = usuario;
            return RedirectToAction("Index", "crm_menu");
        }

        public ActionResult Index(string ID_USUARIO, string CLAVE)
        {
            ViewBag.Error = "Login o password no pueden estar vacíos";

            if (string.IsNullOrEmpty(ID_USUARIO) ||
            string.IsNullOrEmpty(CLAVE))
            {
                ViewBag.Error = "Login o password no pueden estar vacíos";
                return View();
            }
            // Damos de alta el usuario en la BBDD y redireccionamos
            Session["usuario"] = ID_USUARIO;
            return RedirectToAction("Index", "crm_menu");
        }





    }
}
