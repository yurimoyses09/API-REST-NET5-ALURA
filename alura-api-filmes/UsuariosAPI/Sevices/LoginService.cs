using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

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

                Token token = _tokenService.CreateToken(useridentity, _signInManager.UserManager.GetRolesAsync(useridentity).Result.FirstOrDefault()); 

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Falha ao realizar o Login do usuario");
        }

        internal Result SolicitaResetaSenhaUsuario(SolicitaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);

            if (identityUser != null)
            {
                string token = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;

                return Result.Ok().WithSuccess(token);
            }

            return Result.Fail("Falha ao solicitar redefinicao de senha");


        }

        internal Result ResetaResetaSenhaUsuario(EfetuaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);

            IdentityResult resultIdentity = _signInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.RePassword).Result;

            if (resultIdentity.Succeeded) return Result.Ok().WithSuccess("Senha alterada com sucesso");

            return Result.Fail("Falha ao redefinir senha");
        }

        private IdentityUser<int> RecuperaUsuarioPorEmail(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(x => x.NormalizedEmail == email.ToUpper());
        }
    }
}
