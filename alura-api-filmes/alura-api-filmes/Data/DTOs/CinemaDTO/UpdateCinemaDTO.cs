using System.ComponentModel.DataAnnotations;

namespace alura_api_filmes.Data.DTOs.CinemaDTO
{
    public class UpdateCinemaDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}
