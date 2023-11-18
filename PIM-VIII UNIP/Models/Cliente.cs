using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII_UNIP.Models
{
   
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(256,ErrorMessage ="Nome não pode ter mais que 256 caracteres")]
        public string Nome { get; set; } = null!;
        public long Cpf { get; set; }
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        [ForeignKey("Endereco")]
        public int EnderecoID { get; set; }
        public Endereco Endereco { get; set; } = null!;
    }
}
