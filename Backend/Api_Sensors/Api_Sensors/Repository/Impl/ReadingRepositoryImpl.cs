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
                .Where(x => x.ReadingDate >= startDate && x.ReadingDate <= endDate)
                .ToListAsync();

            var readingDto = readings.Select(x => new ReadingDto
            {
                SensorName = x.Sensor.Name,
                ReadingDate = x.ReadingDate,
                Value = x.Value,
            }).ToList();

            return readingDto;
        }
    }
}
