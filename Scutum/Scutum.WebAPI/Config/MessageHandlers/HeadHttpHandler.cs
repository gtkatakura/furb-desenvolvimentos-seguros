using System.Net.Http;
using System.Threading.Tasks;

namespace Scutum.WebAPI.Config.MessageHandlers
{
    public class HeadHttpHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Head)
            {
                request.Method = HttpMethod.Get;
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}