using System;
using System.ComponentModel.DataAnnotations;

namespace alura_api_filmes.Data.DTOs
{
    public class ReadEnderecoDTO
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}
