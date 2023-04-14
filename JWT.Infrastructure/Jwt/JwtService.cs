using JSWSample.Domain.Auth;
using JWTSample.Application.IJwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JSWSample.Infrastructure.Jwt
{
    public class JwtService  
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToke(User user)
        {
            try
            {
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var expired = DateTime.UtcNow.AddMinutes(5);
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
                var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var claims = new Claim[]
                {
                 new Claim("UserId", user.UserID.ToString()),
                 new Claim("Username", user.Username)
                };

                var token = new JwtSecurityToken(claims: claims, expires: expired, signingCredentials: credential);

                var tokenHandler = new JwtSecurityTokenHandler();
                var stringToken = tokenHandler.WriteToken(token);

                return stringToken;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
