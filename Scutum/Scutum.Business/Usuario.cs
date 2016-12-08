using Scutum.Data;
using Scutum.Infra.MongoDB;
using Scutum.Library.Security;
using Scutum.Model;

namespace Scutum.Business
{
    public class Usuario : Base<Data.Usuario, Model.Usuario>
    {
        private UsuarioRepositoryMongo mongo = new UsuarioRepositoryMongo();

        public Usuario()
        {
        }

        public Model.Usuario Find(string nome)
        {
            return base.data.Find(nome);
        }

        public Model.Usuario Find(string nome, string senha)
        {
            var user = this.Find(nome);

            if (!PasswordStorage.VerifyPassword(senha, user.SenhaHashed))
            {
                return null;
            }

            return user;
        }

        public override int Save(Model.Usuario model)
        {
            var result = base.Save(model);
            this.mongo.Save(model);
            return result;
        }

        public override int Update(Model.Usuario model)
        {
            var result = base.Update(model);
            this.mongo.Update(model);
            return result;
        }

        public override int Remove(Model.Usuario model)
        {
            var result = base.Remove(model);
            this.mongo.Remove(model);
            return result;
        }
    }
}