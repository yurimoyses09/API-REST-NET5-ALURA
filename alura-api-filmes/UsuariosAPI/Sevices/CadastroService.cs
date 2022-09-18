using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Data;
using UsuariosAPI.Data.DTOs.UsuarioDTO;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Sevices
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UsuarioDbContext _context;
        private UserManager<IdentityUser<int>> _userManager;

        public CadastroService(UsuarioDbContext context, IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            IdentityUser<int> identity = _mapper.Map<IdentityUser<int>>(usuario);

            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(identity, usuario.Password);

            if (resultadoIdentity.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(identity).Result;
                return Result.Ok().WithSuccess(code);
            }

            return Result.Fail("Falha ao cadastrar usuario");
        }

        public Result AtivaContaUsuario(AtivaContaRequest ativaConta)
        {
            var identityUser = _userManager.Users.FirstOrDefault(x => x.Id == ativaConta.UsuarioId);

            var identityResult = _userManager.ConfirmEmailAsync(identityUser, ativaConta.CodigoAtivacao).Result;

            if (identityResult.Succeeded) return Result.Ok();

            return Result.Fail("Falha ao confirmar email");
        }
    }
}
