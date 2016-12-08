using Scutum.WebAPI.Config.Formatters.ContractResolvers;
using Scutum.WebAPI.Config.Formatters.Formattings;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace Scutum.WebAPI.Config.Formatters
{
    public class JsonPascalCaseMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public JsonPascalCaseMediaTypeFormatter()
        {
            base.MediaTypeMappings.Add(new ContractResolverHeaderMapping("pascal-case"));
        }
    }
}