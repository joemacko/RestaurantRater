using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RestaurantRater
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Web API routes
            config.MapHttpAttributeRoutes();

            // This part of the code is mapping an HttpRoute for the DefaultApi route.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                // Every route for the API defaults to using the route below
                // {controller} comes from the "ValuesController" class and drops the "controller" suffix in the route
                routeTemplate: "api/{controller}/{id}",
                // The id is a RouteParameter, which is optional. Some controller methods have it (e.g., PUT, DELETE), some don't.
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
