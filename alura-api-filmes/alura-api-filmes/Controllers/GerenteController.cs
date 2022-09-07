using alura_api_filmes.Data;
using alura_api_filmes.Data.DTOs;
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
    public class GerenteController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public GerenteController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateGerente(CreateGerenteDTO gerenteDTO)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDTO);

            _context.Add(gerente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetGerentePerId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult GetGerentePerId(int id)
        {
            try
            {
                Gerente gerente = _context.Gerente.FirstOrDefault(x => x.Id == id);

                ReadGerenteDTO gerenteDto = _mapper.Map<ReadGerenteDTO>(gerente);

                return Ok(gerente);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
