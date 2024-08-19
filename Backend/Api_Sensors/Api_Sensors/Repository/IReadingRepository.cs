using Api_Sensors.Dto.Reading;

namespace Api_Sensors.Repository
{
    public interface IReadingRepository
    {
        Task<List<ReadingDto>> GetReadingsByDates(DateOnly startDate, DateOnly endDate);

        Task<ReadingDto> CreateReading(string sensorName);
    }
}
