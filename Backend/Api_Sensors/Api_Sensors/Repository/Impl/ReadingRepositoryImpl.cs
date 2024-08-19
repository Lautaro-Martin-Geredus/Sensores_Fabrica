using Api_Sensors.Dto.Reading;
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

        public async Task<List<ReadingDto>> GetReadingsByDates(DateOnly startDate, DateOnly endDate)
        {
            var readings = await _context.Readings
                .Include(r => r.Sensor)
                .Where(x => x.ReadingDate >= startDate && x.ReadingDate <= endDate)
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
