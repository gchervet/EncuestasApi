using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace EncuestasApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ControllersApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            //var enableCorsAttribute = new EnableCorsAttribute("*",
            //                                   "Origin, Content-Type, Accept, Authorization",
            //                                   "GET, PUT, POST, DELETE, OPTIONS");
            //config.EnableCors(enableCorsAttribute);

        }
    }
}
