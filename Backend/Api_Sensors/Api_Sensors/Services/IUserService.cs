using Api_Sensors.Dto.Sensor;
using Api_Sensors.Dto.User;

namespace Api_Sensors.Services
{
    public interface IUserService
    {
        Task<UserDto> PostUser(UserDto userDto);

        Task<bool> LoggUser(LoginRequest loginRequest);
    }
}
