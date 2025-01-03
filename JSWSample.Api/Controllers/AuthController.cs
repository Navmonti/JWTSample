using JSWSample.Domain.Auth;
using JSWSample.Domain.IServices;
using JWTSample.Api.ViewModel;
using JWTSample.Domain.Dtos;
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
        public async Task<IActionResult> Login(LoginModel model)
            => Ok(await _authService.LoginAsync(model.Username, model.Password));

        [HttpPost]
        public async Task<IActionResult> SignUp(SignupModel model)
        {
            SignUpDto signupDtoObj = new SignUpDto();
            signupDtoObj.Firstname = model.Firstname;
            signupDtoObj.Lastname = model.Lastname;
            signupDtoObj.Username = model.Username;
            signupDtoObj.Password = model.Password;
            signupDtoObj.ConfirmPassword = model.ConfirmPassword;
            signupDtoObj.Email = model.Email;
            signupDtoObj.PhoneNumber = model.PhoneNumber;

            return Ok(await _authService.SignupAsync(signupDtoObj));
        }
    }
}
