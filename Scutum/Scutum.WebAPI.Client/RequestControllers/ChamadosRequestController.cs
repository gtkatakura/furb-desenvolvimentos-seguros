using RestSharp;
using Scutum.Model;

namespace Scutum.WebAPI.Client.RequestControllers
{
    public class ChamadosRequestController : BaseRequestController<Chamado>
    {
        public ChamadosRequestController(RestClient restClient)
            : base(restClient, "Chamados")
        {
        }
    }
}