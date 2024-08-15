using Api_Sensors.Dto.User;
using Api_Sensors.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Sensors.Repository.Impl
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly ApiSensoresContext _context;

        public UserRepositoryImpl(ApiSensoresContext context)
        {
            _context = context;
        }

        public async Task<bool> LoggUser(LoginRequest loginRequest)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginRequest.Email && x.Password == loginRequest.Password);
            if(result == null)
            {
                throw new InvalidOperationException("There is no registered user with that email");
                return false;
            }
            return true;
        }

        public async Task<UserDto> CreateUser(UserDto userDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == userDto.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("There is already a user with that email!");
            }

            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
                Description = userDto.Description,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Description = user.Description,
            };
        }
    }
}
