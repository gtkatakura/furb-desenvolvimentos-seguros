using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;

namespace Scutum.WebAPI.Config.Formatters.Formattings
{
    public class ContractResolverHeaderMapping : RequestHeaderMapping
    {
        public ContractResolverHeaderMapping(string headerValue, string mediaType = "application/json")
            : base("Contract-Resolver", headerValue, StringComparison.InvariantCultureIgnoreCase, false, mediaType)
        {
            
        }
    }
}