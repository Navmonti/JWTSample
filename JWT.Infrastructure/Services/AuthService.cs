using JSWSample.Domain.Auth;
using JSWSample.Domain.IServices;
using JSWSample.Infrastructure.Shared;
using JWTSample.Application.IJwt;
using JWTSample.Application.IRepositories;

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
    }
}
