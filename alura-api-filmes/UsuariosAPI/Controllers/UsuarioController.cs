﻿using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Data.DTOs.UsuarioDTO;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Sevices;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private CadastroService _cadastroUsuario;

        public UsuarioController(CadastroService cadastroUsuario)
        {
            _cadastroUsuario = cadastroUsuario;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto usuarioDto)
        {
            Result resultado = _cadastroUsuario.CadastraUsuario(usuarioDto);

            if (resultado.IsFailed) return StatusCode(500);

            return Ok(resultado.Successes);
        }

        [HttpPost("/ativa")]
        public IActionResult AtivaConta(AtivaContaRequest ativaConta)
        {
            Result result = _cadastroUsuario.AtivaContaUsuario(ativaConta);
            if (result.IsFailed) return StatusCode(500);

            return Ok(result.Successes);
        }
    }
}
