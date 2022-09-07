using System;
using System.ComponentModel.DataAnnotations;

namespace alura_api_filmes.Data.DTOs
{
    public class CreateFilmeDTO
    {
        [Required(ErrorMessage = "Titulo Campo obrigatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Diretor Campo obrigatorio")]
        public string Diretor { get; set; }

        public string Genero { get; set; }

        [Range(1, 500, ErrorMessage = "Duracao muito curta ou muito longa")]
        public int Duracao { get; set; }
    }
}
