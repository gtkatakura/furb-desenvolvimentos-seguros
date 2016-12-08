using Scutum.WebAPI.Config.Security;
using Scutum.WebAPI.Logging;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Scutum.Library.Helper;
using System.Linq;

namespace Scutum.WebAPI.Config.Filters
{
    public class AuthorizeFilter : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated && this.IsAuthorized())
            {
                return true;
            }

            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.Headers.WwwAuthenticate.Add(AuthorizationUtil.AuthenticationHeader);

            actionContext.Response = response;

            this.LoggingUnauthorizedRequest(actionContext.Request);

            return false;
        }

        private void LoggingUnauthorizedRequest(HttpRequestMessage request)
        {
            var ip = request.GetClientIpAddress();
            var userName = Thread.CurrentPrincipal.Identity.Name;

            NLogger.Instance.Warn($@"Request Headers (IP = {ip}, User = {userName}): {request.Headers.ToString()}");
        }

        private bool IsAuthorized()
        {
            var roles = this.Roles.Split(',').Select(role => role.Trim());
            return roles.Any(role => Thread.CurrentPrincipal.IsInRole(role));
        }
    }
}
