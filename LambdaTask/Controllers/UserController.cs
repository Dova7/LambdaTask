using Application.Contracts.IServices.Identity;
using Application.Models.Identity.Dtos;
using LambdaTask.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LambdaTask.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            var response = new APIResponse
            {
                IsSuccess = true,
                Result = users,
                Message = "All users retrieved successfully.",
                StatusCode = StatusCodes.Status200OK
            };
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            var response = new APIResponse
            {
                IsSuccess = true,
                Result = user,
                Message = "User retrieved successfully.",
                StatusCode = StatusCodes.Status200OK
            };
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("by-email")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            var response = new APIResponse
            {
                IsSuccess = true,
                Result = user,
                Message = "User by email retrieved successfully.",
                StatusCode = StatusCodes.Status200OK
            };
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("by-username")]
        public async Task<IActionResult> GetUserByUserName([FromQuery] string username)
        {
            var user = await _userService.GetUserByUsernameAsync(username);
            var response = new APIResponse
            {
                IsSuccess = true,
                Result = user,
                Message = "User by username retrieved successfully.",
                StatusCode = StatusCodes.Status200OK
            };
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("info")]
        public async Task<IActionResult> UpdateUser(UpdateUserInfoDto updateDto)
        {
            var updatedUser = await _userService.UpdateUserInfoAsync(updateDto);
            var response = new APIResponse
            {
                IsSuccess = true,
                Result = updatedUser,
                Message = "User updated successfully.",
                StatusCode = StatusCodes.Status200OK
            };
            return StatusCode(response.StatusCode, response);
        }
    }
}
