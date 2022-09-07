﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace alura_api_filmes.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public virtual Cinema Cinema { get; set; }


    }
}
