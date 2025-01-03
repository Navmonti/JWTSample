using JSWSample.Domain.Auth;
using JSWSample.Domain.IServices;
using JSWSample.Infrastructure.Repositories;
using JSWSample.Infrastructure.Shared;
using JWTSample.Application.IJwt;
using JWTSample.Application.IRepositories;
using JWTSample.Domain.Dtos;

namespace JSWSample.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService; 
        public AuthService(IAuthRepository authRepository, IJwtService jwtService , IUserService userService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
            _userService = userService;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            try
            {
                var hashedPassword = new Utiles().HashedString(password);
                var user = await _authRepository.Login(username, hashedPassword);
                if (user is null) { return null; }
                var token = _jwtService.GetTokenAsync(user);

                //Update Token/TokenExpireDate
                user.Token = token;
                user.TokenExpireDate = DateTime.UtcNow.AddDays(7);
                _userService.Update(user);

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<User> SignupAsync(SignUpDto model)
        {
            try
            {
                var validate = CheckPassword(model.Password, model.ConfirmPassword);
                if (!validate) throw new Exception("password and confirmPassword is not equal");

                var userObj = new User();
                userObj.Firstname = model.Firstname;
                userObj.Lastname = model.Lastname;
                userObj.Username = model.Username;
                userObj.Password = model.Password;  
                userObj.TokenExpireDate = DateTime.UtcNow.AddDays(7);

                return userObj;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool CheckPassword(string password, string confirmPassword)
        {
            if (password == confirmPassword) return true;
            return false;
        }

    }
}
