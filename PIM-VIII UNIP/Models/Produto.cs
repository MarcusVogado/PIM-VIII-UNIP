using PIM_VIII_UNIP.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII_UNIP.Models
{
    
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; } = null!;
        [Required]
        public string Descricao { get; set; } = null!;
        [Required]
        [DisplayName("Preço")]
        public double Preco { get; set; }
        [Required]
        [DisplayName("Caminho da Imagem")]
        public string ImagePath { get; set; } = null!;
        public ProdutoStatus Status { get; set; }
        [ForeignKey("Vendedor")]
        public int VendedorID { get; set; }
        public Vendedor Vendedor { get; set; } = null!;
        public ProdutoCategoria  Categoria { get; set; }
    }
}
