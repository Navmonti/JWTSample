using JSWSample.Domain.Auth;

namespace JWTSample.Application.IRepositories
{
    public interface IAuthRepository
    {
        Task<User> Login(string username, string password);
        Task<User> Signup(User user);
    }
}
