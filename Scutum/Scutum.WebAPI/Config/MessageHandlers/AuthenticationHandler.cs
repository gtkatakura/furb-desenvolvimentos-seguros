using Scutum.Model;
using Scutum.WebAPI.Config.Security;
using Scutum.WebAPI.Helper;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Scutum.WebAPI.Config.MessageHandlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Model.Usuario user = null;
            
            if (AuthorizationUtil.IsValid(request.Headers.Authorization, out user))
            {
                var roles = IdentityUtil.GetRoles(user);
                var principal = new GenericPrincipal(new GenericIdentity(user.Nome), roles);

                CurrentPrincipalUtil.SetPrincipal(principal);
            }
            
            return base.SendAsync(request, cancellationToken);
        }
    }
}