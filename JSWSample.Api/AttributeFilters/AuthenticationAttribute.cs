using JSWSample.Domain.Auth;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace JSWSample.Api.AttributeFilters
{
    public class AuthenticationAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
             
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

            if (jwtSecurityToken != null)
            {
                var userclaims = jwtSecurityToken.Claims;
                var user = new User()
                {
                    UserID = Guid.Parse(userclaims.FirstOrDefault(x => x.Type == "UserId")?.Value),
                    Username = userclaims.FirstOrDefault(x => x.Type == "Username")?.Value,
                };
                context.HttpContext.Items["User"] = user;
            }
        }
    }
}
