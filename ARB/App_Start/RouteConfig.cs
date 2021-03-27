using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ARB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapHttpRoute(
                    name: "Api_Get",
                    routeTemplate: "{controller}/{id}/{action}",
                    defaults: new { id = RouteParameter.Optional, action = "Get" },
                    constraints: new { httpMethod = new HttpMethodConstraint("GET") }
                 );

            routes.MapHttpRoute(
               name: "Api_Post",
               routeTemplate: "{controller}/{id}/{action}",
               defaults: new { id = RouteParameter.Optional, action = "Post" },
               constraints: new { httpMethod = new HttpMethodConstraint("POST") }
            );
        }
    }
}
