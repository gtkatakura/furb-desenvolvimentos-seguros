using Scutum.Model.Interface;

namespace Scutum.Model
{
    public class Providencia : IEntityWithID
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public Tarefa Tarefa { get; set; }

        public Providencia()
        {
        }
    }
}