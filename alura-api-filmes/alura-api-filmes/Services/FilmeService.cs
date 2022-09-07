using alura_api_filmes.Data;
using alura_api_filmes.Data.DTOs;
using alura_api_filmes.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alura_api_filmes.Services
{
    public class FilmeService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDTO AdicionaFilme(CreateFilmeDTO filmedto)
        {
            Filme filme = _mapper.Map<Filme>(filmedto);

            _context.Filme.Add(filme);
            _context.SaveChanges();

            return _mapper.Map<ReadFilmeDTO>(filme);
        }

        public ReadFilmeDTO RecuperarFilmes()
        {
            IEnumerable<Filme> filme = _context.Filme;

            ReadFilmeDTO filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);
            
            return filmeDTO;
        }

        public ReadFilmeDTO RecuperarFilmePerId(int id)
        {
            Filme filme = _context.Filme.FirstOrDefault(x => x.Id == id);

            ReadFilmeDTO filmeDto = _mapper.Map<ReadFilmeDTO>(filme);

            return filmeDto;
        }

        public Result AtualizarFilme(UpdateEnderecoDTO filmeDTO, int id)
        {

            Filme filme = _context.Filme.FirstOrDefault(x => x.Id == id);

            if (filme.Equals(null)) return Result.Fail("Filme nao encontrado");

            _mapper.Map(filmeDTO, filme);

            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletarFilme(int id)
        {
            Filme filme = _context.Filme.FirstOrDefault(x => x.Id == id);

            if (filme.Equals(null)) return Result.Fail("Filme nao encontrado");

            _context.Remove(filme);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
