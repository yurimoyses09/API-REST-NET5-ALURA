using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Sevices;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request)
        {
            Result resultado = _loginService.LogaUsuario(request);

            if (resultado.IsFailed) return Unauthorized();

            return Ok(resultado.Successes);
        }

        [HttpPost("/solicita-reset")]
        public IActionResult SolicitaResetaSenhaUsuario(SolicitaResetRequest request)
        {
            Result resultado = _loginService.SolicitaResetaSenhaUsuario(request);

            if (resultado.IsFailed) return Unauthorized(resultado.Errors);

            return Ok(resultado.Successes);
        }

        [HttpPost("/efetua-reset")]
        public IActionResult EfetuaResetaSenhaUsuario(EfetuaResetRequest request)
        {
            Result resultado = _loginService.ResetaResetaSenhaUsuario(request);

            if (resultado.IsFailed) return Unauthorized(resultado.Errors);

            return Ok(resultado.Successes);
        }
    }
}
