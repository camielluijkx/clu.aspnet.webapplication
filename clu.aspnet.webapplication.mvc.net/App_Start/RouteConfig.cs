﻿using System.Web.Mvc;
using System.Web.Routing;

namespace clu.aspnet.webapplication.mvc.net
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "CommentRoute", url: "comment/{id}", defaults: new { controller = "Comment", action = "Display" }, constraints: new { id = "[0-9]+" });

            routes.MapRoute(name: "PhotoRoute", url: "photo/{id}", defaults: new { controller = "Photo", action = "Display" }, constraints: new { id = "[0-9]+" });
            routes.MapRoute(name: "PhotoTitleRoute", url: "photo/title/{title}", defaults: new { controller = "Photo", action = "DisplayByTitle" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}