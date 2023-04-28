using Microsoft.AspNetCore.Mvc;

namespace JSWSample.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected Guid GetCurrentUserId()
        {
            Guid userId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId").Value); ;   
            return userId;
        }
    }
}
