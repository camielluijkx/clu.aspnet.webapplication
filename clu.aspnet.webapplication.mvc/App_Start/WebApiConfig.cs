﻿using System.Web.Http;

namespace clu.aspnet.webapplication.mvc.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "PhotoApi",
                routeTemplate: "api/photos/{id}",
                defaults: new { controller = "PhotoApi", action = "GetPhotoById" },
                constraints: new { id = "[0-9]+" }
             );

            config.Routes.MapHttpRoute(
               name: "PhotoTitleApi",
               routeTemplate: "api/photos/{title}",
               defaults: new { controller = "PhotoApi", action = "GetPhotoByTitle" }
            );

            config.Routes.MapHttpRoute(
                name: "PhotosApi",
                routeTemplate: "api/photos",
                defaults: new { controller = "PhotoApi", action = "GetAllPhotos" }
             );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}