using alura_api_filmes.Data.DTOs.CinemaDTO;
using alura_api_filmes.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alura_api_filmes.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDTO, Cinema>();
            CreateMap<Cinema, ReadCinemaDTO>();
            CreateMap<UpdateCinemaDTO, Cinema>();
        }
    }
}
