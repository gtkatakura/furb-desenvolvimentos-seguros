using RestSharp;
using Scutum.Model;

namespace Scutum.WebAPI.Client.RequestControllers
{
    public class TramitesRequestController : BaseRequestController<Tramite>
    {
        public TramitesRequestController(RestClient restClient)
            : base(restClient, "Tramites")
        {
        }
    }
}