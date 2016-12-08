using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Scutum.WebAPI.Config.MessageHandlers
{
    //public class ResponseDataFilterHandler : DelegatingHandler
    //{
    //    protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    //    {
    //        return base.SendAsync(request, cancellationToken)
    //            .ContinueWith(task =>
    //            {
    //                var response = task.Result;

    //                //Manipulate content here
    //                var content = response.Content as ObjectContent;
    //                if (content != null && content.Value != null)
    //                {
    //                    FilterFields(content.Value);
    //                }

    //                return response;
    //            });
    //    }

    //    private void FilterFields(object objectToFilter)
    //    {
    //        var properties = objectToFilter
    //                             .GetType()
    //                             .GetProperties(
    //                                 BindingFlags.IgnoreCase |
    //                                 BindingFlags.GetProperty |
    //                                 BindingFlags.Instance |
    //                                 BindingFlags.Public);

    //        foreach (var propertyInfo in properties)
    //        {
    //            if (propertyInfo.Name.StartsWith("Descricao"))
    //            {
    //                propertyInfo.SetValue(objectToFilter, null);
    //            }
    //        }
    //    }
    //}

    public class ResponseDataFilterHandler : DelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken)
                .ContinueWith(task =>
                {
                    var response = task.Result;
                    var content = response.Content as ObjectContent;
                    if (content != null && content.Value != null)
                    {
                        var isJson = response.RequestMessage.GetQueryNameValuePairs().Any(r => r.Key == "json" && r.Value == "true");
                        response.Content = new StringContent(Helper.GetResponseData(content.Value, isJson));
                    }
                    return response;
                });
        }
    }

    public static class Helper
    {
        public static string GetResponseData(object root, bool isJson)
        {
            string json = JsonConvert.SerializeObject(root, new JsonSerializerSettings { ContractResolver = new ShouldSerializeContractResolver() });

            if (!isJson)
            {
                XmlDocument doc = JsonConvert.DeserializeXmlNode(json);
                json = doc.OuterXml;
            }
            return json;
        }
    }

    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            property.ShouldSerialize = (i) =>
            {
                //Your logic goes here
                var r = !property.PropertyName.StartsWith("Descricao");
                return r;
            };

            return property;
        }
    }
}