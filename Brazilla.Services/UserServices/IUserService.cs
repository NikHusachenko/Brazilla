using Brazilla.Database.Entities;
using Brazilla.Services.UserServices.Models;

namespace Brazilla.Services.UserServices
{
    public interface IUserService
    {
        bool Create(SignUpViewModel vm);
        void Update(UserEntity userEntity);
        void Delete(UserEntity userEntity);
        UserEntity GetById(long id);
        UserEntity GetByLoginAndPassword(string login, string password);
        UserEntity GetByEmailAndLogin(string email, string login);
        UserEntity GetCurrentUser();
        List<UserEntity> GetByEmail(string email);
        Task<bool> SignIn(UserEntity userEntity);
        Task<bool> SignIn(string login, string password);
        Task<bool> SignIn(SignUpViewModel vm);
        void SignOut();
        void Buy(long id);
    }
}