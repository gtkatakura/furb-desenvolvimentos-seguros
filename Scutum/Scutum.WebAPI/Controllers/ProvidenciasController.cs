using Scutum.Business;
using Scutum.Data;
using Scutum.Model;
using Scutum.WebAPI.Config.Filters;
using System.Web.Http;

namespace Scutum.WebAPI.Controllers
{
    [AuthorizeFilter(Roles = "Admin,Atendente")]
    public class ProvidenciasController : BaseApiController<Business.Providencia, Data.Providencia, Model.Providencia>
    {
    }
}