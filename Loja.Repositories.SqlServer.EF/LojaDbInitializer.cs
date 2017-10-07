using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Loja.Dominio;

namespace Loja.Repositories.SqlServer.EF
{
    internal class LojaDbInitializer : DropCreateDatabaseIfModelChanges<LojaDbContext>
    {
        protected override void Seed(LojaDbContext context)
        {
            //if (!context.Categorias.Any())
            //{
                context.Categorias.AddRange(ObterCategorias());
                context.SaveChanges();
            //}

            //if (!context.Produtos.Any())
            //{
                context.Produtos.AddRange(ObterProutos(context));
                context.SaveChanges();
            //}

            base.Seed(context);
        }

        private IEnumerable<Produto> ObterProutos(LojaDbContext context)
        {
            var grampeador = new Produto
            {
                Nome = "Grampeador",
                Preco = 17.27m,
                QtdEstoque = 27,
                Ativo = true,
                Categoria = context.Categorias.Single(x => x.Nome == "Papelaria")
            };

            var penDrive = new Produto
            {
                Nome = "Pen drive",
                Preco = 17.32m,
                QtdEstoque = 32,
                Ativo = true,
                Categoria = context.Categorias.Single(x => x.Nome == "Informática")
            };

            return new List<Produto> { grampeador, penDrive};

        }

        private IEnumerable<Categoria> ObterCategorias()
        {
            return new List<Categoria>
            {
                new Categoria { Nome = "Papelaria"},
                new Categoria { Nome = "Informática"},
                new Categoria { Nome = "Perfumaria"},
            };
            
        }
    }
}