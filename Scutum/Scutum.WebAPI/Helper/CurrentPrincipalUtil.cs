using System.Security.Principal;
using System.Threading;
using System.Web;

namespace Scutum.WebAPI.Helper
{
    public class CurrentPrincipalUtil
    {
        public static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;

            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
    }
}