using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace K_Systems.Presentation.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //   name: "SalesModule",
            //   url: "sales/{controller}/{action}/{id}",
            //   defaults: new { controller = "SalesDashboards", action = "Index", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //   name: "HRModule",
            //   url: "hr/{controller}/{action}/{id}",
            //   defaults: new { controller = "DashBoards", action = "Index", id = UrlParameter.Optional }
            //);


        }
    }
}
