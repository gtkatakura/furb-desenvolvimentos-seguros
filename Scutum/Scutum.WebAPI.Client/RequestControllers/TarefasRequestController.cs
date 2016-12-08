using RestSharp;
using Scutum.Model;

namespace Scutum.WebAPI.Client.RequestControllers
{
    public class TarefasRequestController : BaseRequestController<Tarefa>
    {
        public TarefasRequestController(RestClient restClient)
            : base(restClient, "Tarefas")
        {
        }
    }
}