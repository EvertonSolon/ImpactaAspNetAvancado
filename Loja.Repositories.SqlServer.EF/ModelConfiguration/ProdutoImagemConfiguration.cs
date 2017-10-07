using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositories.SqlServer.EF.ModelConfiguration
{
    public class ProdutoImagemConfiguration : EntityTypeConfiguration<ProdutoImagem>
    {
        public ProdutoImagemConfiguration()
        {
            HasKey(x => x.ProdutoId);

            Property(x => x.ContentType)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}