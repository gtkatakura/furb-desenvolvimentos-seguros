using Scutum.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scutum.Model
{
    public class CartaoCredito : IEntityWithID
    {
        public int Id { get; set; }

        public string NumeroCriptografado { get; set; }

        public string Senha { get; set; }
    }
}
