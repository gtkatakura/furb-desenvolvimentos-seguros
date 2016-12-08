using Scutum.Business;
using Scutum.Data;
using Scutum.Model;
using System;
using System.Linq;
using System.Web.Http;

namespace Scutum.WebAPI.Controllers
{
    public class ChamadosController : BaseApiController<Business.Chamado, Data.Chamado, Model.Chamado>
    {
    }
}