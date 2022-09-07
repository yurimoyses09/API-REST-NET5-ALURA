using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using UsuariosAPI.Data.Requests;

namespace UsuariosAPI.Sevices
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LoginService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        internal Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (resultadoIdentity.Result.Succeeded) return Result.Ok();

            return Result.Fail("Falha ao realizar o Login do usuario");
        }
    }
}
