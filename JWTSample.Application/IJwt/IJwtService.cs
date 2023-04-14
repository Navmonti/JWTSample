using JSWSample.Domain.Auth; 

namespace JWTSample.Application.IJwt
{
    public interface IJwtService
    {
        string GenerateToke(User user);
        bool IsValid(string Token);
    }
}
