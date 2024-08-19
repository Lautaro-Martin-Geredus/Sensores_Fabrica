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

        public async Task<List<ReadingDto>> GetReadingsByDates(DateOnly startDate, DateOnly endDate)
        {
            return await _readingRepository.GetReadingsByDates(startDate, endDate);
        }
    }
}
