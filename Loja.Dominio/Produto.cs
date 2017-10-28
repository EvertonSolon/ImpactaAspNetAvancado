namespace Loja.Dominio
{
    public class Produto : Base
    {
        //a palavra virtual liga o lazy load.
        public virtual Categoria Categoria { get; set; }
        public virtual ProdutoImagem Imagem { get; set; }
        public decimal Preco { get; set; }
        public int QtdEstoque { get; set; }
        public bool Ativo { get; set; }
        public bool EmLeilao { get; set; }
    }
}
