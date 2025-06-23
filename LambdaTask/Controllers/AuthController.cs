using Application.Contracts.IServices.Identity;
using Application.Models.Identity.Dtos;
using LambdaTask.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LambdaTask.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            var result = await _authService.Login(loginDto);

            var response = new APIResponse
            {
                Result = result,
                IsSuccess = true,
                Message = "User logged in successfully.",
                StatusCode = StatusCodes.Status200OK
            };

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registerDto)
        {
            await _authService.Register(registerDto);

            var response = new APIResponse
            {
                Result = registerDto,
                IsSuccess = true,
                Message = "User registered successfully.",
                StatusCode = StatusCodes.Status200OK
            };

            return StatusCode(response.StatusCode, response);
        }

    }
}
