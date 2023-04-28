using JSWSample.Domain.Auth;
using JWTSample.Application.IJwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JSWSample.Infrastructure.Jwt
{
    public class JwtService  : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetTokenAsync(User user)
        {
            try
            { 
                var expired = DateTime.UtcNow.AddDays(7); 
                var issuer = _configuration["JwtSetting:Issuer"];
                var audience = _configuration["JwtSetting:Audience"];
                var key = _configuration["JwtSetting:SecretKey"];
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)); ;
                var credential = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256);
                var claims = new Claim[]
                {
                 new Claim("UserId", user.UserID.ToString()),
                 new Claim("Username", user.Username)
                };

                var token = new JwtSecurityToken(claims: claims, expires: expired, signingCredentials: credential , audience : audience , issuer : issuer);

                var tokenHandler = new JwtSecurityTokenHandler();
                var stringToken = tokenHandler.WriteToken(token);

                return stringToken;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool IsValid(string Token)
        {
            return false;
        }
    }
}
