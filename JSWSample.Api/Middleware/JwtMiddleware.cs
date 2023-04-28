using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _configuration = configuration;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var issuer = _configuration["JwtSetting:Issuer"];
        var audience = _configuration["JwtSetting:Audience"];
        var key = Encoding.ASCII.GetBytes(_configuration["JwtSetting:SecretKey"]); 

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (token != null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var claimns = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "UserId").Value; 
                var user = new ClaimsPrincipal(claimns);
                context.User = user; 
            }
            catch (SecurityTokenException)
            {
                context.Response.StatusCode = 401;
                return;
            } 
        }
        await _next(context);
    }
}
public static class JwtMiddlewareExtensions
{
    public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<JwtMiddleware>();
    }
}
