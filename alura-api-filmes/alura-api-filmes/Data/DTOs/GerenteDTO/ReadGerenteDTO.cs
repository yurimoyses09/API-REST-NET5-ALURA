using System;
using System.ComponentModel.DataAnnotations;

namespace alura_api_filmes.Data.DTOs
{
    public class ReadGerenteDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int Nome { get; set; }
    }
}
