using Scutum.Business;
using Scutum.Data;
using Scutum.Model;
using Scutum.WebAPI.Config.Filters;

namespace Scutum.WebAPI.Controllers
{
    [AuthorizeFilter(Roles = "Admin,Atendente")]
    public class TarefasController : BaseApiController<Business.Tarefa, Data.Tarefa, Model.Tarefa>
    {
    }
}