using AutoMapper;
using Scutum.WebAPI.Mappers;
using System.Web.Http;

namespace Scutum.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Mapper.Initialize(x =>
                x.AddProfile<CartaoCreditoProfile>()
            );
        }
    }
}