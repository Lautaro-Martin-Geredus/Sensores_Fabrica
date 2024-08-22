using Api_Sensors.Dto.Sensor;
using Api_Sensors.Dto.User;
using Api_Sensors.Repository;

namespace Api_Sensors.Services.Impl
{
    public class UserServiceImpl : IUserService
    {
        private readonly IUserRepository _userRepository;  

        public UserServiceImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> PostUser(UserDto userDto)
        {
            return await _userRepository.CreateUser(userDto);
        }

        public async Task<bool> LoggUser(LoginRequest loginRequest)
        {
            return await _userRepository.LoggUser(loginRequest);
        }
    }
}
