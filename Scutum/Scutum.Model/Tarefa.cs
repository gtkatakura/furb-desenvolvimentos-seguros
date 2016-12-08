using Scutum.Model.Interface;
using System;
using System.Collections.Generic;

namespace Scutum.Model
{
    public class Tarefa : IEntityWithID
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataAbertura { get; set; }

        public ICollection<Providencia> Providencias { get; set; }

        public Tarefa()
        {
        }
    }
}