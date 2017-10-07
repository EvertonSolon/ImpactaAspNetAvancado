using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositories.SqlServer.EF.ModelConfiguration
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            Property(x => x.Nome)
               .IsRequired()
               .HasMaxLength(50);
        }
    }
}