using JSWSample.Api.ViewModels;
using JSWSample.Domain.Auth;
using Microsoft.AspNetCore.Mvc;

namespace JSWSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {

        }

        [HttpPost]
        public async Task<IActionResult> Signup(User user)
        {
            return Ok(await);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            return Ok(null);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(string token)
        {
            return Ok(null);
        }
    }
}
