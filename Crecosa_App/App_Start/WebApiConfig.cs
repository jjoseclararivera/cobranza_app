using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace CrecosaWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling =
                Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);


            // Rutas de API web
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "Default",
            //    //routeTemplate: "api/{controller}/{id}",
            //    //defaults: new { id = RouteParameter.Optional }
            //    routeTemplate: "crm/{controller}/{action}/{id}", 
            //    defaults: new { controller = "menu", action = "Index", id = RouteParameter.Optional }
            //);
        }
    }
}
