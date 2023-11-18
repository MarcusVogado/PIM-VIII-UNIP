using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII_UNIP.Models
{
    
    public class ItemCarrinho
    {
        [Key]
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal { get; set; }

        [ForeignKey("Carrinho")]
        public int? CarrinhoID { get; set; }
        public Carrinho Carrinho { get; set; }
        [ForeignKey("Produto")]
        public int? ProdutoID { get; set; }
        public Produto Produto { get; set; } 
    }
}
