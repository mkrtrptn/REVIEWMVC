using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace webapiclientserverapp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{eid}",
                defaults: new { eid = RouteParameter.Optional }
            );
        }
    }
}
