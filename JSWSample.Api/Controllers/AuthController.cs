using JSWSample.Domain.Auth;
using JSWSample.Domain.IServices;
using Microsoft.AspNetCore.Mvc;

namespace JSWSample.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController] 
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }  

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
            => Ok(await _authService.LoginAsync(username, password));
    }
}
