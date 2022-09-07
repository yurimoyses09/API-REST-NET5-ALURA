using alura_api_filmes.Data.DTOs;
using alura_api_filmes.Models;
using AutoMapper;

namespace alura_api_filmes.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDTO, Endereco>();
            CreateMap<Endereco, ReadEnderecoDTO>();
            CreateMap<UpdateEnderecoDTO, Endereco>();
        }
    }
}
