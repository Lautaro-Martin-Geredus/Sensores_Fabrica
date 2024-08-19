using Api_Sensors.Dto.Reading;

namespace Api_Sensors.Services
{
    public interface IReadingService
    {
        Task<List<ReadingDto>> GetReadingsByDates(DateOnly startDate, DateOnly endDate);

        Task<ReadingDto> CreateReading(string sensorName);
    }
}
