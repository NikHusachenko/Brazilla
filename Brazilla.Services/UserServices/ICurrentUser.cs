using Brazilla.Database.Entities;
using Brazilla.Database.Enums;

namespace Brazilla.Services.UserServices
{
    public interface ICurrentUser
    {
        long? Id { get; }
        string? Email { get; }
        string? Login { get; }
        bool? IsAuthenticated { get; }
        bool? IsAdmin { get; }
        UserTypes? Role { get; }
    }
}