using Scutum.Data;
using Scutum.Model;
using System;
using System.Linq;

namespace Scutum.Business
{
    public class Tarefa : Base<Data.Tarefa, Model.Tarefa>
    {
        public Tarefa()
        {
        }

        public override int Save(Model.Tarefa model)
        {
            model.DataAbertura = DateTime.Now;
            return base.Save(model);
        }

        public IQueryable<Model.Providencia> GetProvidencias(int id)
        {
            return this.data.GetProvidencias(id);
        }
    }
}