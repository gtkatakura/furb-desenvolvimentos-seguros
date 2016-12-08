using Newtonsoft.Json;
using RestSharp.Serializers;
using Scutum.WebAPI.Config.Formatters.ContractResolvers;

namespace Scutum.ConsoleTest.Serializers
{
    public class JsonLowerCaseUnderscoreSerializer : ISerializer
    {
        public string ContentType { get; set; }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public JsonLowerCaseUnderscoreSerializer()
        {
            this.ContentType = "application/json";
        }

        public string Serialize(object obj)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new LowerCaseUnderscoreContractResolver();

            return JsonConvert.SerializeObject(obj, serializerSettings);
        }
    }
}