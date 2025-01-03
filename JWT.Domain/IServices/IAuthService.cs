using JSWSample.Domain.Auth;
using JWTSample.Domain.Dtos;

namespace JSWSample.Domain.IServices
{
    public interface IAuthService
    {
        Task<User> LoginAsync(string username, string password);
        Task<User> SignupAsync(SignUpDto model);
    }
}
