using alura_api_filmes.Data;
using alura_api_filmes.Data.DTOs;
using alura_api_filmes.Models;
using alura_api_filmes.Services;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace alura_api_filmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;
        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult CreateFilme([FromBody] CreateFilmeDTO filmedto)
        {
            try
            {
                ReadFilmeDTO filmeDTO = _filmeService.AdicionaFilme(filmedto);

                return CreatedAtAction(nameof(GetFilmePerId), new { Id = filmeDTO.Id }, filmeDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetFilmes()
        {
            try
            {
                return Ok(_filmeService.RecuperarFilmes());
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmePerId(int id)
        {
            try
            {
                ReadFilmeDTO filme =  _filmeService.RecuperarFilmePerId(id);

                return Ok(filme);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilme(int id, [FromBody] UpdateEnderecoDTO filmeDTO)
        {
            Result filme = _filmeService.AtualizarFilme(filmeDTO, id);

            if (filme.IsFailed) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id)
        {
            Result filme = _filmeService.DeletarFilme(id);
            
            if (filme.IsFailed) return NotFound();

            return NoContent();
        }

    }
}
