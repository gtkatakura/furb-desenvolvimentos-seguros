using Scutum.WebAPI.Config.Formatters;
using Scutum.WebAPI.Config.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;

namespace Scutum.WebAPI.Config.Helper
{
    public static class HttpConfigurationUtil
    {
        public static IEnumerable<DelegatingHandler> GetCustomMessageHandlers()
        {
            return new List<DelegatingHandler>
            {
                new AuthenticationHandler(),
                new HeadHttpHandler(),
                new OptionsHttpHandler()
                //,new ResponseDataFilterHandler()
            };
        }

        public static IEnumerable<MediaTypeFormatter> GetCustomFormatters()
        {
            return new List<MediaTypeFormatter>
            {
                new BsonMediaTypeFormatter(),
                new JsonCamelCaseMediaTypeFormatter(),
                new JsonLowerCaseUnderscoreMediaTypeFormatter(),
                new JsonPascalCaseMediaTypeFormatter()
            };
        }
    }
}