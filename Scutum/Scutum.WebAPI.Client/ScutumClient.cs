using Scutum.Model.Interface;
using Scutum.WebAPI.Client.RequestControllers;

namespace Scutum.WebAPI.Client
{
    public class ScutumClient
    {
        private ScutumRestClient restClient;
        
        public ChamadosRequestController Chamados { get; set; }

        public ProvidenciasRequestController Providencias { get; set; }

        public TarefasRequestController Tarefas { get; set; }

        public TramitesRequestController Tramites { get; set; }

        public ScutumClient(string baseAdress)
        {
            this.restClient = new ScutumRestClient(baseAdress);

            this.Chamados = new ChamadosRequestController(restClient);
            this.Providencias = new ProvidenciasRequestController(restClient);
            this.Tarefas = new TarefasRequestController(restClient);
            this.Tramites = new TramitesRequestController(restClient);
        }

        public void Authorize(string username, string password)
        {
            this.restClient.Authenticate(username, password);
        }

        public void Deauthorize()
        {
            this.restClient.Deauthenticate();
        }

        public BaseRequestController<T> CreateRequestController<T>()
            where T : IEntityWithID, new()
        {
            return new BaseRequestController<T>(this.restClient, typeof(T).Name + "s");
        }
    }
}