using JSWSample.Domain.Auth; 

namespace JSWSample.Domain.IServices
{
    public interface IAuthService
    {
        Task<User> LoginAsync(string username, string password);
    }
}
