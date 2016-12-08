using Scutum.Model;
using System.Linq;

namespace Scutum.Data
{
    public class Tarefa : Base<Model.Tarefa>
    {
        public Tarefa()
        {
        }

        public IQueryable<Model.Providencia> GetProvidencias(int id)
        {
            return base.Get(id).SelectMany(x => x.Providencias);
        }
    }
}