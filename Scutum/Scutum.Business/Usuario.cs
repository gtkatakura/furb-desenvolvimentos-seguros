using Scutum.Data;
using Scutum.Library.Security;
using Scutum.Model;

namespace Scutum.Business
{
    public class Usuario : Base<Data.Usuario, Model.Usuario>
    {
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
    }
}