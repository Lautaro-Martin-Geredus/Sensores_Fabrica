using Api_Sensors.Dto.Reading;
using Api_Sensors.Repository;
using Api_Sensors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Sensors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingController : ControllerBase
    {
        private readonly IReadingRepository _readingRepository;
        
        public ReadingController(IReadingRepository readingRepository)
        {
            _readingRepository = readingRepository;
        }

        [HttpGet("GetReadingsByDates")]
        public async Task<ActionResult<ReadingDto>> GetReadings([FromQuery] DateOnly startDate, [FromQuery] DateOnly endDate)  // Error aqui al mandar las fechas
        {
            try
            {
                var readings = await _readingRepository.GetReadingsByDates(startDate, endDate);

                if (readings == null || !readings.Any())
                {
                    return NotFound("No readings found for the given date range.");
                }

                return Ok(readings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
