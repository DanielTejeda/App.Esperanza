using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace App.Esperanza.WebApi
{
    public class RouteConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes(); // se coloca esto para poder usar Routeprefix

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
