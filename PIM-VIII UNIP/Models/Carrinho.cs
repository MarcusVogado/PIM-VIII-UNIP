using PIM_VIII_UNIP.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII_UNIP.Models
{
    
    public class Carrinho
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        [Required]
        public double ValorTotal { get; set; }
        [Required]
        public PedidoStatus Status { get; set; }
        [ForeignKey("Cliente")]
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; } = null!;        
        [NotMapped]
        public virtual List<ItemCarrinho> ProdutosCarrinho { get; set; }
    }
}
