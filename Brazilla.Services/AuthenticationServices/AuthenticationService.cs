using Brazilla.Commons;
using Brazilla.Database.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Brazilla.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpContext _httpContext;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async void SignOut()
        {
            await _httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        
        public async Task<bool> SignIn(UserEntity userEntity)
        {
            var claims = GetClaimsList(userEntity);
            var identity = GetClaimsIdentity(claims);
            var principal = new ClaimsPrincipal(identity);
            await _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return true;
        }

        public ClaimsIdentity GetClaimsIdentity(List<Claim> claims)
        {
            return new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }
        public List<Claim> GetClaimsList(UserEntity userEntity)
        {
            return new List<Claim>()
            {
                new Claim(Claims.EMAIL, userEntity.Email),
                new Claim(Claims.ID, userEntity.Id.ToString()),
                new Claim(Claims.LOGIN, userEntity.Login),
                new Claim(Claims.ROLE, userEntity.Type.ToString()),
            };
        }
    }
}