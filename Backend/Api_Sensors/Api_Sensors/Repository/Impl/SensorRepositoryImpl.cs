using Api_Sensors.Dto.Sensor;
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

        public async Task<SensorDto> PutSensor(Guid id, SensorDto sensorDto)
        {
            var sensor = await _context.Sensors.FirstOrDefaultAsync(s => s.Id.Equals(id));
            if (sensor == null)
            {
                throw new InvalidOperationException("There is no sensor with that ID!");
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
    }
}
