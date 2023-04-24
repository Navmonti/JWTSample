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
        public AuthService(IAuthRepository authRepository, IJwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            try
            {
                var hashedPassword = new Utiles().HashedString(password);
                var user = await _authRepository.Login(username, hashedPassword);
                if (user is null) { return null; }

                var token = _jwtService.GetTokenAsync(user);
                return token.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> SignupAsync(User user)
        {
            try
            {
                return await _authRepository.Signup(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
