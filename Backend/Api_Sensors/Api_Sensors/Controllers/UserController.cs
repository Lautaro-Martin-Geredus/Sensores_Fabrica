using Api_Sensors.Dto.Sensor;
using Api_Sensors.Dto.User;
using Api_Sensors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Sensors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("LoggingUser")]
        public async Task<ActionResult<bool>> LoggingUser([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || loginRequest.Password == "")
            {
                return BadRequest("Invalid login request data.");
            }

            try
            {
                var result = await _userService.LoggUser(loginRequest);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserDto>> CreateNewUser([FromBody] UserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var resultDto = await _userService.PostUser(userDto);
                return Ok(resultDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
