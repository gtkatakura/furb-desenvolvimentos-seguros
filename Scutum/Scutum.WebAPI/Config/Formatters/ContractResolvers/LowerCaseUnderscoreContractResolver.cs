using Newtonsoft.Json.Serialization;
using System.Text.RegularExpressions;

namespace Scutum.WebAPI.Config.Formatters.ContractResolvers
{
    public class LowerCaseUnderscoreContractResolver : DefaultContractResolver
    {
        private Regex regex = new Regex("(?!(^[A-Z]))([A-Z])");

        protected override string ResolvePropertyName(string propertyName)
        {
            return regex.Replace(propertyName, "_$2").ToLower();
        }
    }
}