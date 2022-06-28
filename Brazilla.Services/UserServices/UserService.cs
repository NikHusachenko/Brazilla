using Brazilla.Database.Entities;
using Brazilla.EntityFramework.Repository;
using Brazilla.Services.AuthenticationServices;
using Brazilla.Services.UserServices.Models;
using Microsoft.EntityFrameworkCore;

namespace Brazilla.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<UserEntity> _genericRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly ICurrentUser _currentUser;

        public UserService(IGenericRepository<UserEntity> genericRepository,
            IAuthenticationService authenticationService,
            ICurrentUser currentUser)
        {
            _genericRepository = genericRepository;
            _authenticationService = authenticationService;
            _currentUser = currentUser;
        }

        // User checked by email and login
        // On one email can create any accounts
        // if they have differend logins
        public bool Create(SignUpViewModel vm)
        {
            if (GetByEmailAndLogin(vm.Email, vm.Login) != null)
            {
                return false;
            }

            UserEntity dbRecord = new UserEntity()
            {
                CreatedOn = DateTime.Now,
                Email = vm.Email,
                Login = vm.Login,
                Password = vm.Password,
                Type = Database.Enums.UserTypes.Client,
            };

            _genericRepository.Create(dbRecord);
            
            return true;
        }

        public void Delete(UserEntity userEntity)
        {
            userEntity.DeletedOn = DateTime.Now;
            Update(userEntity);
        }

        public UserEntity GetById(long id)
        {
            return _genericRepository?.Table?
                .Include(user => user.Blends)
                .ThenInclude(blend => blend.Type)
                .FirstOrDefault(user => user.Id == id);
        }

        public UserEntity GetByLoginAndPassword(string login, string password)
        {
            return _genericRepository.Table
                .Include(user => user.Blends)
                .ThenInclude(blend => blend.Type)
                .FirstOrDefault(user => user.Login == login && password == password);
        }
        
        public async Task<bool> SignIn(UserEntity userEntity)
        {
            await _authenticationService.SignIn(userEntity);
            return true;
        }

        public async Task<bool> SignIn(string login, string password)
        {
            var user = _genericRepository.Table
                .FirstOrDefault(user => user.Login == login && user.Password == password);

            if(user == null)
            {
                return false;
            }

            await _authenticationService.SignIn(user);
            return true;
        }

        public void SignOut()
        {
            _authenticationService.SignOut();
        }

        public void Update(UserEntity userEntity)
        {
            _genericRepository.Update(userEntity);
        }

        public UserEntity GetByEmailAndLogin(string email, string login)
        {
            return _genericRepository.Table
                .Include(user => user.Blends)
                .ThenInclude(blend => blend.Type)
                .FirstOrDefault(user => user.Email == email && user.Login == login);
        }

        public List<UserEntity> GetByEmail(string email)
        {
            return _genericRepository.Table
                .Include(user => user.Blends)
                .ThenInclude(blend => blend.Type)
                .ToList();
        }

        public async Task<bool> SignIn(SignUpViewModel vm)
        {
            UserEntity userEntity = GetByLoginAndPassword(vm.Login, vm.Password);
            if(userEntity == null)
            {
                return false;
            }

            await _authenticationService.SignIn(userEntity);
            return true;
        }

        public UserEntity GetCurrentUser()
        {
            long id = long.Parse(_currentUser.Id.ToString());
            return GetById(id);
        }

        public void Buy(long id)
        {
            var user = GetCurrentUser();
            user.Blends.Remove(user.Blends.First(blend => blend.Id == id));
            Update(user);
        }
    }
}