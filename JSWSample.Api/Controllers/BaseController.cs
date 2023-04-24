using JSWSample.Domain.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSWSample.Api.Controllers
{
    [ApiController]
    public class BaseController : Controller
    {
        protected User GetUser()
        {
            // Get the user information from the HttpContext.Items dictionary
            if (HttpContext.Items.TryGetValue("user", out var user))
            {
                var x = (User)user;
                return x;
            }

            return null;
        }
    }
}
