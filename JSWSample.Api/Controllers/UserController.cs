using JSWSample.Domain.Auth;
using JSWSample.Domain.IServices;
using Microsoft.AspNetCore.Mvc;

namespace JSWSample.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(User user) =>
              Ok(await _userService.Insert(user));

        [HttpPut]
        public async Task<IActionResult> Update(User user) =>
               Ok(await _userService.Update(user));

        [HttpDelete]
        public async Task<IActionResult> Delete(User user) =>
            Ok(await _userService.Update(user));

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = GetCurrentUserId();
            return Ok(await _userService.GetAll());
        }

        [HttpGet("userId")]
        public async Task<IActionResult> GetById(int userId) =>
            Ok(await _userService.GetById(userId));

        [HttpGet("username")]
        public async Task<IActionResult> GetByUsername(string username) =>
           Ok(await _userService.GetByUsername(username));
    }
}
