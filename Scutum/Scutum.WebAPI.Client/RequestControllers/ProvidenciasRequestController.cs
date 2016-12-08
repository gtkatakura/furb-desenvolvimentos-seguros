using RestSharp;
using Scutum.Model;

namespace Scutum.WebAPI.Client.RequestControllers
{
    public class ProvidenciasRequestController : BaseRequestController<Providencia>
    {
        public ProvidenciasRequestController(RestClient restClient)
            : base(restClient, "Providencias")
        {
        }
    }
}