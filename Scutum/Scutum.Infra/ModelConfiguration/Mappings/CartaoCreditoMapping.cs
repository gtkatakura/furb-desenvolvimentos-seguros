using Scutum.Model;
using System.Data.Entity.ModelConfiguration;

namespace Scutum.Infra.ModelConfiguration.Mappings
{
    public class CartaoCreditoMapping : EntityTypeConfiguration<Model.CartaoCredito>
    {
        public CartaoCreditoMapping()
        {
            this.Property(x => x.NumeroCriptografado)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(1000)
                .IsRequired();

            this.Ignore(x => x.Senha);
        }
    }
}