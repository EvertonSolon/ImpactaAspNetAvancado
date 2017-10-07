using System.Collections.Generic;

namespace Loja.Dominio
{
    public class Categoria : Base
    {
        public virtual List<Produto> Produtos { get; set; }
    }
}