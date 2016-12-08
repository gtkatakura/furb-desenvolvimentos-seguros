using System;
using System.Linq;
using System.Linq.Expressions;

namespace Scutum.Data
{
    public class Chamado : Base<Model.Chamado>
    {
        public Chamado()
        {
        }

        public IQueryable<Model.Tramite> GetTramites(int id)
        {
            return base.Get(id).SelectMany(chamado => chamado.Tramites);
        }
    }
}