namespace PIM_VIII_UNIP.Models.ViewModels
{
    public class CarrinhoView
    {
        public double ValorTotal { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<ItemCarrinho> ItensCarrinho { get; set; }
    }
}
