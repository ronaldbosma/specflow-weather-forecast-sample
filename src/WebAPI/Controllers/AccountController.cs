using Microsoft.AspNetCore.Mvc;
using WeatherForecastSample.Shared.Authentication;
using WeatherForecastSample.WebAPI.ApplicationLogic;

namespace WeatherForecastSample.WebAPI.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest userForAuthentication)
        {
            var validCredentials = await _authenticationService.AreCredentialsValidAsync(userForAuthentication.Username, userForAuthentication.Password);
            if (!validCredentials)
            {
                return Unauthorized(new LoginResponse { ErrorMessage = "Login failed due to invalid credentials." });
            }

            var token = _authenticationService.GenerateToken(userForAuthentication.Username);

            return Ok(new LoginResponse { IsAuthenticationSuccessful = true, Token = token });
        }
    }
}
