using Scutum.Model;
using System.Data.Entity.ModelConfiguration;

namespace Scutum.Infra.ModelConfiguration.Mappings
{
    public class TramiteMapping : EntityTypeConfiguration<Model.Tramite>
    {

        public TramiteMapping()
        {
            this.HasRequired(l => l.Chamado)
                .WithMany(r => r.Tramites)
                .Map(l => l.MapKey("ChamadoID"));

            this.Property(x => x.Descricao)
                .HasColumnType("NVARCHAR");
        }
    }
}