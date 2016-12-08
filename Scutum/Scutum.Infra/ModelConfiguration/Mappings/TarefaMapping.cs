using Scutum.Model;
using System.Data.Entity.ModelConfiguration;

namespace Scutum.Infra.ModelConfiguration.Mappings
{
    public class TarefaMapping : EntityTypeConfiguration<Model.Tarefa>
    {
        public TarefaMapping()
        {
            this.Property(x => x.Descricao)
                .HasColumnType("NVARCHAR");

            this.Property(x => x.Titulo)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(1000);

            this.Property(x => x.DataAbertura)
                .HasColumnType("DATETIME")
                .IsRequired();
        }
    }
}