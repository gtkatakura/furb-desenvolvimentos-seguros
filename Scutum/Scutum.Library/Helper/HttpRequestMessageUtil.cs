using System.Net.Http;

namespace Scutum.Library.Helper
{
    public class HttpRequestMessageUtil
    {
        public static long GetRequestLength(HttpRequestMessage request)
        {
            return (long)request.Content.Headers.ContentLength + request.Headers.ToString().Length;
        }
    }
}