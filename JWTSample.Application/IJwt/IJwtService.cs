using JSWSample.Domain.Auth; 

namespace JWTSample.Application.IJwt
{
    public interface IJwtService
    {
        string GetTokenAsync(User user);
        bool IsValid(string Token);
    }
}
