using alura_api_filmes.Data;
using alura_api_filmes.Data.DTOs;
using alura_api_filmes.Data.DTOs.CinemaDTO;
using alura_api_filmes.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alura_api_filmes.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDTO cinemaDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(cinemaDto);
            _context.Endereco.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<Cinema> RecuperaEndereco([FromQuery] string nomeDoFilme)
        {
            return _context.Cinema;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            Endereco endereco = _context.Endereco.FirstOrDefault(x => x.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDTO cinemaDto = _mapper.Map<ReadEnderecoDTO>(endereco);
                return Ok(cinemaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDTO cinemaDto)
        {
            Endereco endereco = _context.Endereco.FirstOrDefault(x => x.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Endereco endereco = _context.Endereco.FirstOrDefault(x => x.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
