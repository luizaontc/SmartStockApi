using SmartStock.Data.Repository.Interface;
using SmartStock.Domain.DTO;
using SmartStock.Domain.Entities;
using SmartStock.Service.Interface;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartStock.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        public AuthService(IAuthRepository dbRepository)
        {
            _repository = dbRepository;
        }
        public User DoLogin(UserDTO user)
        {
            try
            {
                var response = _repository.DoLogin(user);

                if (response == null)
                {
                    throw new Exception();
                };

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, response.Name));
                claims.Add(new Claim(ClaimTypes.Role, "Administrador"));

                //var claimsIdentity =
                //    new ClaimsPrincipal(
                //        new ClaimsIdentity(
                //           claims,
                //           CookieAuthenticationDefaults.AuthenticationScheme
                //        )
                //    );

                //var authProperties = new AuthenticationProperties
                //{
                //    ExpiresUtc = DateTime.Now.AddHours(1),
                //    IssuedUtc = DateTime.Now
                //};

                //await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception ("Usuário não encontrado");
            }
            
        }
    }
}
