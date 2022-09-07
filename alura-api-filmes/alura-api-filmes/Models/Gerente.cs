using System.ComponentModel.DataAnnotations;

namespace alura_api_filmes.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int Nome { get; set; }
    }
}
