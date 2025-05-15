using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FSPPApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Маршрут для CustomController с методом start и id=0
            routes.MapRoute(
                name: "Start",
                url: "Custom/start/0",
                defaults: new { controller = "Custom", action = "start", id = 0 }
            );

            // Маршрут для CustomController с другими параметрами
            routes.MapRoute(
                name: "Custom",
                url: "Custom/{action}/{id}",
                defaults: new { controller = "Custom", id = UrlParameter.Optional }
            );

            // Стандартный маршрут
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
} 