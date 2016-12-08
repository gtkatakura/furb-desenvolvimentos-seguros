using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Scutum.WebAPI.Config.MessageHandlers
{
    public class OptionsHttpHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method != HttpMethod.Options)
            {
                return base.SendAsync(request, cancellationToken);
            }

            return Task.Factory.StartNew(() =>
            {
                var apiExplorer = GlobalConfiguration.Configuration.Services.GetApiExplorer();
                var controllerRequested = request.GetRouteData().Values["controller"].ToString();
                var supportedMethods = apiExplorer.ApiDescriptions
                    .Where(x =>
                    {
                        var controller = x.ActionDescriptor.ControllerDescriptor.ControllerName;
                        return controller.Equals(controllerRequested, StringComparison.OrdinalIgnoreCase);
                    })
                    .Select(x => x.HttpMethod)
                    .Distinct()
                    .OrderBy(x => x.Method);

                if (!supportedMethods.Any())
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Headers.Add("Access-Control-Allow-Origin", "*");
                response.Headers.Add("Access-Control-Allow-Methods", String.Join(",", supportedMethods));
                return response;
            });
        }
    }
}