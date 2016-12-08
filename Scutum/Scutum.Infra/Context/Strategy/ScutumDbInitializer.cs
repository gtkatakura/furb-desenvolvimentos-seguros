using Scutum.Infra.MongoDB;
using Scutum.Model;
using Scutum.Model.Enumerator;
using System;
using System.Data.Entity;
using System.Linq;

namespace Scutum.Infra.Context.Strategy
{
    // CreateDatabaseIfNotExists
    // DropCreateDatabaseAlways
    public class ScutumDbInitializer : CreateDatabaseIfNotExists<ScutumContext>
    {
        private static bool Normalized = false;

        public void NormalizeUsers(ScutumContext context)
        {
            if (!Normalized)
            {
                var usuarioRepository = new UsuarioRepositoryMongo();

                var usuarios = context.Usuarios.ToArray();

                foreach (var usuario in usuarios)
                {
                    var usuarioCache = usuarioRepository.Find(usuario.Id);
                    
                    if (usuarioCache == null)
                    {
                        context.Usuarios.Remove(usuario);
                    }
                    else if (usuario.Nivel != usuarioCache.Nivel ||
                        usuario.Nome != usuarioCache.Nome ||
                        usuario.SenhaHashed != usuarioCache.SenhaHashed)
                    {
                        usuario.Nivel = usuarioCache.Nivel;
                        usuario.Nome = usuarioCache.Nome;
                        usuario.SenhaHashed = usuarioCache.SenhaHashed;

                        context.Usuarios.Attach(usuario);
                        context.Entry(usuario).State = EntityState.Modified;
                    }
                }

                context.SaveChanges();

                Normalized = true;
            }
        }

        protected override void Seed(ScutumContext context)
        {
            var admin = new Usuario
            {
                Nome = "Admin",
                Senha = "1",
                Nivel = ENivel.Admin
            };

            var atendente = new Usuario
            {
                Nome = "Takashi",
                Senha = "1",
                Nivel = ENivel.Atendente
            };

            var chamado1 = new Chamado
            {
                Titulo = "Primeiro Chamado - Título (DbInitializer)",
                Descricao = "Primeiro Chamado - Descrição (DbInitializer)",
                DataAbertura = DateTime.Now
            };

            var chamado2 = new Chamado
            {
                Titulo = "Segundo Chamado - Título (DbInitializer)",
                Descricao = "Segundo Chamado - Descrição (DbInitializer)",
                DataAbertura = DateTime.Now
            };

            var tramite1 = new Tramite
            {
                Chamado = chamado1,
                Descricao = "Primeiro Trâmite - Descrição (DbInitializer)"
            };

            var tarefa1 = new Tarefa
            {
                Titulo = "Primeira Tarefa - Título (DbInitializer)",
                Descricao = "Primeira Tarefa - Descrição (DbInitializer)",
                DataAbertura = DateTime.Now
            };

            var tarefa2 = new Tarefa
            {
                Titulo = "Segunda Tarefa - Título (DbInitializer)",
                Descricao = "Segunda Tarefa - Descrição (DbInitializer)",
                DataAbertura = DateTime.Now
            };

            var providencia1 = new Providencia
            {
                Tarefa = tarefa1,
                Descricao = "Primeira Providência - Descrição (DbInitializer)"
            };

            var usuarioRepository = new UsuarioRepositoryMongo();

            context.Usuarios.Add(admin);
            context.Usuarios.Add(atendente);

            context.Chamados.Add(chamado1);
            context.Chamados.Add(chamado2);
            context.Tramites.Add(tramite1);

            context.Tarefas.Add(tarefa1);
            context.Tarefas.Add(tarefa2);
            context.Providencias.Add(providencia1);

            context.SaveChanges();

            usuarioRepository.Save(admin);
            usuarioRepository.Save(atendente);

            base.Seed(context);
        }
    }
}