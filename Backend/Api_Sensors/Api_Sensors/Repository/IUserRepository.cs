using Api_Sensors.Dto.User;

namespace Api_Sensors.Repository
{
    public interface IUserRepository
    {
        Task<UserDto> CreateUser(UserDto userDto);

        Task<bool> LoggUser(LoginRequest loginRequest);
    }
}
