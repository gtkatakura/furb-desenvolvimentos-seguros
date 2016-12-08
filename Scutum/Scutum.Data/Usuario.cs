using Scutum.Model;
using System.Linq;

namespace Scutum.Data
{
    public class Usuario : Base<Model.Usuario>
    {
        public Usuario()
        {
        }

        public IQueryable<Model.Usuario> Get(string nome)
        {
            return (
                from
                    usuario in base.context.Usuarios
                where
                    usuario.Nome == nome
                select
                    usuario
            );
        }

        public IQueryable<Model.Usuario> Get(string nome, string senha)
        {
            var query = (
                from
                    usuario in this.Get(nome)
                where
                    usuario.Senha == senha
                select
                    usuario
            );

            return query;
        }

        public Model.Usuario Find(string nome)
        {
            return this.Get(nome).FirstOrDefault();
        }

        public Model.Usuario Find(string nome, string senha)
        {
            return this.Get(nome, senha).FirstOrDefault();
        }

        public bool Exists(string nome, string senha)
        {
            return this.Get(nome, senha).Any();
        }
    }
}