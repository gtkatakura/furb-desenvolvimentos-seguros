using Scutum.Model;
using System.Web.Mvc;

namespace Scutum.Web.Controllers
{
    public class ChamadosController : BaseController<Chamado>
    {
        public override ActionResult Create(Chamado model)
        {
            return base.Create(model);
        }
    }
}