using System.Net.Http;

namespace Scutum.Library.Helper
{
    public class HttpResponseMessageUtil
    {
        public static long GetResponseLength(HttpResponseMessage response)
        {
            if (response.Content != null)
            {
                response.Content.LoadIntoBufferAsync().Wait();
                return (long)response.Content.Headers.ContentLength + response.Headers.ToString().Length;
            }

            return 0L;
        }
    }
}