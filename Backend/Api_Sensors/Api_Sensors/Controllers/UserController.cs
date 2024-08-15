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
        public async Task<ActionResult<bool>> LoggingUser(string email, int password)
        {
            var result = await _userService.LoggUser(email, password);
            return Ok(result);
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
