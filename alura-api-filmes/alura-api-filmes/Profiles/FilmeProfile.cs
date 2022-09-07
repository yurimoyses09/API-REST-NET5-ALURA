using alura_api_filmes.Data.DTOs;
using alura_api_filmes.Models;
using AutoMapper;

namespace alura_api_filmes.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<Filme, ReadFilmeDTO>();
            CreateMap<UpdateEnderecoDTO, Filme>();
        }
    }
}
