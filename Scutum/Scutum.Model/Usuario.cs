using Scutum.Model.Enumerator;
using Scutum.Model.Interface;
using Scutum.Library.Security;

namespace Scutum.Model
{
    public class Usuario : IEntityWithID
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string SenhaHashed { get; set; }

        public ENivel Nivel { get; set; }

        private string senha;
        public string Senha
        {
            get
            {
                return senha;
            }
            set
            {
                this.senha = value;
                this.SenhaHashed = PasswordStorage.CreateHash(value);
            }
        }

        public Usuario()
        {
        }
    }
}