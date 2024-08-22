using Api_Sensors.Dto.Reading;
using Api_Sensors.Repository;

namespace Api_Sensors.Services.Impl
{
    public class ReadingServiceImpl : IReadingService
    {
        private readonly IReadingRepository _readingRepository;

        public ReadingServiceImpl(IReadingRepository readingRepository)
        {
            _readingRepository = readingRepository;
        }

        public async Task<List<ReadingDto>> GetReadingsByDates(string sensorName,DateOnly startDate, DateOnly endDate)
        {
            return await _readingRepository.GetReadingsByDates(sensorName, startDate, endDate);
        }

        public async Task<ReadingDto> CreateReading(string sensorName)
        {
            return await _readingRepository.CreateReading(sensorName);
        }
    }
}
