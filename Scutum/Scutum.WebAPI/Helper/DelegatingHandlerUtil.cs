using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Scutum.WebAPI.Helper
{
    public static class DelegatingHandlerUtil
    {
        public static void AddRange(this ICollection<DelegatingHandler> that, IEnumerable<DelegatingHandler> handlers)
        {
            foreach (var handler in handlers)
            {
                that.Add(handler);
            }
        }
    }
}