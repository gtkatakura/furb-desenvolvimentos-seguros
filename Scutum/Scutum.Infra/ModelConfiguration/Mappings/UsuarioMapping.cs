using Scutum.Model;
using System.Data.Entity.ModelConfiguration;

namespace Scutum.Infra.ModelConfiguration.Mappings
{
    public class UsuarioMapping : EntityTypeConfiguration<Model.Usuario>
    {
        public UsuarioMapping()
        {
            this.Property(x => x.Nome)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(1000)
                .IsRequired();

            this.Ignore(x => x.Senha);

            this.Property(x => x.SenhaHashed)
                .HasColumnType("NVARCHAR")
                .IsRequired();

            this.Property(x => x.Nivel)
                .HasColumnType("INT")
                .IsRequired();
        }
    }
}