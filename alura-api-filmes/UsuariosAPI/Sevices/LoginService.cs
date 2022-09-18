using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuariosAPI.Data.Requests;

namespace UsuariosAPI.Sevices
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        internal Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (resultadoIdentity.Result.Succeeded)
            {
                var useridentity = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(x => x.NormalizedUserName == request.UserName.ToUpper());

                return Result.Ok().WithSuccess(_tokenService.CreateToken(useridentity).Value);
            }

            return Result.Fail("Falha ao realizar o Login do usuario");
        }
    }
}
