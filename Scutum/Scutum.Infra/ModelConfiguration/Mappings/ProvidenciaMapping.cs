using Scutum.Model;
using System.Data.Entity.ModelConfiguration;

namespace Scutum.Infra.ModelConfiguration.Mappings
{
    public class ProvidenciaMapping : EntityTypeConfiguration<Model.Providencia>
    {
        public ProvidenciaMapping()
        {
            this.HasRequired(l => l.Tarefa)
                .WithMany(r => r.Providencias)
                .Map(l => l.MapKey("TarefaID"));

            this.Property(x => x.Descricao)
                .HasColumnType("NVARCHAR");
        }
    }
}