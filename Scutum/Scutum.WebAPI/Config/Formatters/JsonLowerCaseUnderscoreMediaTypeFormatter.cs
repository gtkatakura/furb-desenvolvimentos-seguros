using Scutum.WebAPI.Config.Formatters.ContractResolvers;
using Scutum.WebAPI.Config.Formatters.Formattings;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace Scutum.WebAPI.Config.Formatters
{
    public class JsonLowerCaseUnderscoreMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public JsonLowerCaseUnderscoreMediaTypeFormatter()
        {
            base.MediaTypeMappings.Add(new ContractResolverHeaderMapping("lower-case-underscore"));
            base.SerializerSettings.ContractResolver = new LowerCaseUnderscoreContractResolver();
        }
    }
}