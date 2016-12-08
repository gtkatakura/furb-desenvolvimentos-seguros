using Scutum.Data;
using Scutum.Model;
using System;
using System.Linq;

namespace Scutum.Business
{
    public class Chamado : Base<Data.Chamado, Model.Chamado>
    {
        public Chamado()
        {
        }

        public override int Save(Model.Chamado model)
        {
            model.DataAbertura = DateTime.Now;
            return base.Save(model);
        }

        public IQueryable<Model.Tramite> GetTramites(int id)
        {
            return this.data.GetTramites(id);
        }
    }
}