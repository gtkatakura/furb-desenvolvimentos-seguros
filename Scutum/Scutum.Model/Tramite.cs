using Scutum.Model.Interface;

namespace Scutum.Model
{
    public class Tramite : IEntityWithID
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public Chamado Chamado { get; set; }

        public Tramite()
        {
        }
    }
}