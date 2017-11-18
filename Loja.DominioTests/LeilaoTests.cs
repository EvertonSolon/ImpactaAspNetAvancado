using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Tests
{
    [TestClass()]
    public class LeilaoTests
    {
        [TestMethod()]
        public void ValidarSucessoTest()
        {
            //Arrange
            var leilao = new Leilao {
                Id = 1,
                Nome = "Lote 1683",
                Preco = 90,
                Produtos = new List<Produto>
                {
                    new Produto { Preco = 100}
                }
            };

            //Act
            var erros = leilao.Validar();

            //Assert
            Assert.IsTrue(erros.Count == 0);
        }

        [TestMethod()]
        public void ValidarFalhaTest()
        {
            //Arrange
            var leilao = new Leilao
            {
                Id = 1,
                Nome = " ",
                Preco = 89,
                Produtos = new List<Produto>
                {
                    new Produto { Preco = 100}
                }
            };

            //Act
            var erros = leilao.Validar();

            //Assert
            Assert.IsTrue(erros.Contains("Nome do Lote é obrigatório.") &&
                          erros.Contains("Desconto máximo excedido."));
        }
    }
}