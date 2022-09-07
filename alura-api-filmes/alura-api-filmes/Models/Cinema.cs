using System.ComponentModel.DataAnnotations;

namespace alura_api_filmes.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        public string Nome { get; set; }

        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
    }
}
