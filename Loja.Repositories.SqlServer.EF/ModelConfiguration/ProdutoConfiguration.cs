using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositories.SqlServer.EF.ModelConfiguration
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(x => x.Preco)
                .HasPrecision(9, 2);

            HasOptional(produto => produto.Imagem)
                .WithRequired(produtoImagem => produtoImagem.Produto)
                .WillCascadeOnDelete(true);
        }
    }
}