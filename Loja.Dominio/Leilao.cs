using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public class Leilao : Base
    {
        public const decimal DescontoMaximo = 0.1m;
        public decimal Preco { get; set; }
        public List<Produto> Produtos { get; set; }

        public List<string> Validar()
        {
            var erros = new List<string>();

            if(string.IsNullOrEmpty(Nome?.Trim()))
            {
                erros.Add("Nome do Lote é obrigatório.");
            }

            var somaProdutos = Produtos.Sum(p => p.Preco);

            if(somaProdutos - Preco > somaProdutos * DescontoMaximo)
            {
                erros.Add("Desconto máximo excedido.");
            }

            return erros;
        }
    }
}
