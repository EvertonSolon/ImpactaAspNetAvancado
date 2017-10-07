using Loja.Dominio;
using Loja.Repositories.SqlServer.EF.Migrations;
using Loja.Repositories.SqlServer.EF.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Repositories.SqlServer.EF
{
    public class LojaDbContext : DbContext
    {
        //FazerEmCasa: Design Pattern Unity of Work.
        public LojaDbContext() : base("name=LojaConnectionString")
        {
            //Pág. 191 - Estratégias de inicialização.
            //Database.SetInitializer(new LojaDbInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LojaDbContext, Configuration>());
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoImagemConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
