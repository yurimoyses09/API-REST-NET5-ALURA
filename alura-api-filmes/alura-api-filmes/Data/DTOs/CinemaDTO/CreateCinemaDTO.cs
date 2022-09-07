using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace alura_api_filmes.Data.DTOs.CinemaDTO
{
    public class CreateCinemaDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public int EnderecoID { get; set; }
    }
}
