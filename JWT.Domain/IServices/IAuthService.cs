using JSWSample.Domain.Auth; 

namespace JSWSample.Domain.IServices
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string username, string password);
        Task<User> SignupAsync(User user);
    }
}
