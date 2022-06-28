using Brazilla.Database.Entities;
using System.Security.Claims;

namespace Brazilla.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        Task<bool> SignIn(UserEntity userEntity);
        void SignOut();
        ClaimsIdentity GetClaimsIdentity(List<Claim> claims);
        List<Claim> GetClaimsList(UserEntity userEntity);
    }
}