using alura_api_filmes.Data.DTOs;
using alura_api_filmes.Models;
using AutoMapper;

namespace alura_api_filmes.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDTO, Gerente>();
            CreateMap<Gerente, ReadGerenteDTO>();
            CreateMap<UpdateGerenteDTO, Gerente>();
        }
    }
}
