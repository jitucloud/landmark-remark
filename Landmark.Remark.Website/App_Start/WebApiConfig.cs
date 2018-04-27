using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Landmark.Remark.Website
{
    /// <summary>
    /// Route Config for WEB API
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            // Web API routes
            config.MapHttpAttributeRoutes();

        }
    }
}
