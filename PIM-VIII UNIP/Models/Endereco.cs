using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIM_VIII_UNIP.Models
{
   
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        public int Cep { get; set; }       
        public string Bairro { get; set; } = null!;
        public string Cidade { get; set; } = null!;       
        public string Logradouro { get; set; } = null!;
        public int Numero { get; set; } 
        public string Complemento { get; set; } = null!;
    }
}
