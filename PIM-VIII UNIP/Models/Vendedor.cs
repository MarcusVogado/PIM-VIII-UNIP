using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII_UNIP.Models
{
    [Table("Vendedores")]
    public class Vendedor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RazaoSocial { get; set; } = null!;
        [Required]
        public string NomeFantasia { get; set; } = null!;
        [Required]
        public string Cnpj { get; set; } = null!;
        [Required,EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Senha { get; set; } = null!;
        public double Comissao { get; set; }
        [Required]
        [ForeignKey("Endereco")]
        public int EnderocoID { get; set; }
        public Endereco Endereco { get; set; } = null!;
    }
}
