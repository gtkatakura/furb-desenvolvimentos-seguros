using Scutum.Infra.Context.Strategy;
using Scutum.Infra.ModelConfiguration.Conventions;
using Scutum.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace Scutum.Infra.Context
{
    public class ScutumContext : DbContext
    {
        public DbSet<Chamado> Chamados { get; set; }

        public DbSet<Providencia> Providencias { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }

        public DbSet<Tramite> Tramites { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public ScutumContext()
            : this("name=Scutum")
        { }

        public ScutumContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            var strategy = new ScutumDbInitializer();
            Database.SetInitializer(strategy);
            strategy.NormalizeUsers(this);

            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add<IdentityConvention>();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}