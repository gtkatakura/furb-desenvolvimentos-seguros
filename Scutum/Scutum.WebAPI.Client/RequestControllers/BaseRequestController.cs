using RestSharp;
using Scutum.Model.Interface;
using System.Collections.Generic;

namespace Scutum.WebAPI.Client.RequestControllers
{
    public class BaseRequestController<T>
        where T : IEntityWithID, new()
    {
        protected readonly IRestClient restClient;
        protected readonly string controllerName;

        public BaseRequestController(IRestClient restClient, string controllerName)
        {
            this.restClient = restClient;
            this.controllerName = controllerName;
        }

        public virtual IRestRequest CreateRestRequest()
        {
            return new RestRequest(this.controllerName);
        }

        public virtual IRestRequest CreateRestRequest(int id)
        {
            return new RestRequest(this.controllerName + "/" + id.ToString());
        }

        public virtual IRestRequest CreateRestRequest(T model, int id = 0)
        {
            var request = id == 0 ? this.CreateRestRequest() : this.CreateRestRequest(id);
            request.AddObject(model);
            return request;
        }

        public virtual IRestResponse<List<T>> Get()
        {
            return this.restClient.Get<List<T>>(this.CreateRestRequest());
        }

        public virtual IRestResponse<T> Find(int id)
        {
            return this.restClient.Get<T>(this.CreateRestRequest(id));
        }

        public virtual IRestResponse<T> Save(T model)
        {
            return this.restClient.Post<T>(this.CreateRestRequest(model));
        }

        public virtual IRestResponse Update(T model)
        {
            return this.restClient.Put(this.CreateRestRequest(model, model.Id));
        }

        public virtual IRestResponse<T> Remove(int id)
        {
            return this.restClient.Delete<T>(this.CreateRestRequest(id));
        }
    }
}