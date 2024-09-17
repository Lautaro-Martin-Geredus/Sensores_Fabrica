namespace Api_Sensors.Dto.Reading.extra
{
    public class extra
    {
        /*
         * using Api_Sensors.Dto.Reading;
using Api_Sensors.Models;
using Api_Sensors.Services;
using Microsoft.EntityFrameworkCore;

namespace Api_Sensors.Repository.Impl
{
    public class ReadingRepositoryImpl : IReadingRepository
    {
        private readonly ApiSensoresContext _context;
        private readonly ISensorService _sensorService;

        public ReadingRepositoryImpl(ApiSensoresContext context, ISensorService sensorService)
        {
            _context = context;
            _sensorService = sensorService;
        }

        public async Task<List<ReadingDto>> GetReadingsByDates(string sensorName, DateOnly startDate, DateOnly endDate)
        {
            var readings = await _context.Readings
                .Include(r => r.Sensor)
                .Where(x => x.Sensor.Name == sensorName && x.ReadingDate >= startDate && x.ReadingDate <= endDate)
                .ToListAsync();

            var readingDto = readings.Select(x => new ReadingDto
            {
                SensorName = x.Sensor?.Name,
                ReadingDate = x.ReadingDate,
                Value = x.Value,
            }).ToList();

            return readingDto;
        }

        public async Task<ReadingDto> CreateReading(string sensorName)
        {
            var sensor = await _context.Sensors.FirstOrDefaultAsync(s => s.Name == sensorName);
            if(sensor == null)
            {
                throw new InvalidOperationException("Sensor not found");
            }

            var random = new Random();
            double randomValue = random.NextDouble() * 100;
            double roundedValue = Math.Round(randomValue, 1);

            var reading = new Reading
            {
                Id = Guid.NewGuid(),
                Sensor = sensor,
                ReadingDate = DateOnly.FromDateTime(DateTime.UtcNow),
                Value = roundedValue
            };

            _context.Readings.Add(reading);
            await _context.SaveChangesAsync();

            return new ReadingDto
            {
                SensorName = sensor.Name,
                ReadingDate = DateOnly.FromDateTime(DateTime.UtcNow),
                Value = roundedValue
            };
        }
    }
}


        sing Api_Sensors.Dto.Sensor;
using Api_Sensors.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Sensors.Repository.Impl
{
    public class SensorRepositoryImpl : ISensorRepository
    {
        private readonly ApiSensoresContext _context;

        public SensorRepositoryImpl(ApiSensoresContext context)
        {
            _context = context;
        }

        public async Task<List<SensorDto>> GetSensors()
        {
            return await _context.Sensors.
                Select(s => new SensorDto
                {
                    Name = s.Name,
                    Description = s.Description,
                    Unit = s.Unit
                })
                .ToListAsync();
        }

        public async Task<SensorDto> PostSensor(SensorDto sensorDto)
        {
            var existingSensor = await _context.Sensors.FirstOrDefaultAsync(x => x.Name == sensorDto.Name);
            if(existingSensor != null)
            {
                throw new InvalidOperationException("There is already a sensor with that name!");
            }

            var sensor = new Sensor
            {
                Id = Guid.NewGuid(),
                Name = sensorDto.Name,
                Description = sensorDto.Description,
                Unit = sensorDto.Unit
            };

            _context.Sensors.Add(sensor);
            await _context.SaveChangesAsync();

            return new SensorDto
            {
                Name = sensor.Name,
                Description = sensor.Description,
                Unit = sensor.Unit
            };
        }

        public async Task<SensorDto> GetSensorByName(string name)
        {
            var sensor = await _context.Sensors.FirstOrDefaultAsync(s => s.Name == name);
            if(sensor == null)
            {
                throw new InvalidOperationException($"There is no sensor with that name: {name}!");
            }

            return new SensorDto
            {
                Name = sensor.Name,
                Description = sensor.Description,
                Unit = sensor.Unit
            };
        }

        public async Task<SensorDto> PutSensor(string name, SensorDto sensorDto)
        {
            var sensor = await _context.Sensors.FirstOrDefaultAsync(s => s.Name == name);
            if (sensor == null)
            {
                throw new InvalidOperationException("There is no sensor with that Name!");
            }
            
            sensor.Name = sensorDto.Name;
            sensor.Description = sensorDto.Description;
            sensor.Unit = sensorDto.Unit;

            await _context.SaveChangesAsync();

            return new SensorDto
            {
                Name= sensor.Name,
                Description = sensor.Description,
                Unit = sensor.Unit
            };
        }

        public async Task<bool> DeleteSensor(string name)
        {
            var sensor = await _context.Sensors.FirstOrDefaultAsync(s => s.Name == name);
            if (sensor == null)
            {
                return false; 
            }

            _context.Remove(sensor);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

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

         */
    }
}
