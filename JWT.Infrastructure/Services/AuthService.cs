using JSWSample.Domain.Auth;
using JSWSample.Domain.IServices;
using JWTSample.Application.IRepositories;

namespace JSWSample.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<User> Login(string username, string password)
        {
            try
            {
                return await _authRepository.Login(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> Signup(User user)
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
