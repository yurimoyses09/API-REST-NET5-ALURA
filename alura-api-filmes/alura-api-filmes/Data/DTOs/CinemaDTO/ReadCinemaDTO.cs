using alura_api_filmes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace alura_api_filmes.Data.DTOs.CinemaDTO
{
    public class ReadCinemaDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
    }
}
