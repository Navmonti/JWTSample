using JSWSample.Domain.Auth; 

namespace JSWSample.Domain.IServices
{
    public interface IAuthService
    {
        Task<User> Login(string username, string password);
        Task<User> Signup(User user);
    }
}
