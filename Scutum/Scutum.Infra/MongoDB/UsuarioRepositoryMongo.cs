using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scutum.Model;

namespace Scutum.Infra.MongoDB
{
    public class UsuarioRepositoryMongo : RepositoryMongo<Model.Usuario>
    {
        public override void Save(Usuario model)
        {
            model.Senha = null;
            base.Save(model);
        }

        public override void Update(Usuario model)
        {
            model.Senha = null;
            base.Update(model);
        }
    }
}
