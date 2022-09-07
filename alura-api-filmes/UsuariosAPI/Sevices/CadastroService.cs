using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using UsuariosAPI.Data;
using UsuariosAPI.Data.DTOs.UsuarioDTO;
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

        internal Result CadastraUsuario(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            IdentityUser<int> identity = _mapper.Map<IdentityUser<int>>(usuario);

            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(identity, usuario.Password);

            if (resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuario");
        }
    }
}
