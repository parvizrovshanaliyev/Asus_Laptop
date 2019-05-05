using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AsusLaptop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(
            //    name:"Admin",
            //    url: "Admin/{controller}/{action}/{id}",
            //    defaults: new { area = "Admin", controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new string[] { "AsusLaptop.Areas.Admin.Controllers" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            
                namespaces: new string[] {"AsusLaptop.Controllers"}
                );
        }
    }
}
