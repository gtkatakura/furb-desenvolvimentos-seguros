using Scutum.Model;
using Scutum.WebAPI.Config.Filters;
using Scutum.WebAPI.Config.Formatters;
using Scutum.WebAPI.Config.Services;
using Scutum.WebAPI.Config.MessageHandlers;
using Scutum.WebAPI.Helper;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Collections.ObjectModel;
using System.Net.Http;
using Scutum.WebAPI.Config.Helper;
using System.Web.Http.Tracing;

namespace Scutum.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "API/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Services.Add(typeof(IExceptionLogger), new ExceptionTextLogger());
            config.MessageHandlers.AddRange(HttpConfigurationUtil.GetCustomMessageHandlers());

            var formatters = config.Formatters;

            formatters.Remove(formatters.JsonFormatter);
            formatters.AddRange(HttpConfigurationUtil.GetCustomFormatters());
        }
    }
}