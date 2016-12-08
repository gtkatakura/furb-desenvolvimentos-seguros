using Newtonsoft.Json.Serialization;
using Scutum.WebAPI.Config.Formatters.ContractResolvers;
using Scutum.WebAPI.Config.Formatters.Formattings;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace Scutum.WebAPI.Config.Formatters
{
    public class JsonCamelCaseMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public JsonCamelCaseMediaTypeFormatter()
        {
            base.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}