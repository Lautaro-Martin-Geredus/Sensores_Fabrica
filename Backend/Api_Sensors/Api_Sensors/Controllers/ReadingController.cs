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
        private readonly IReadingService _readingService;
        
        public ReadingController(IReadingService readingService)
        {
            _readingService = readingService;
        }

        [HttpGet("GetReadingsByDates")]
        public async Task<ActionResult<List<ReadingDto>>> GetReadings([FromQuery] string sensorName, [FromQuery] string startDate, [FromQuery] string endDate)
        {
            try
            {
                DateOnly start = DateOnly.Parse(startDate);
                DateOnly end = DateOnly.Parse(endDate);

                var readings = await _readingService.GetReadingsByDates(sensorName, start, end);

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

        [HttpPost("CreateReading")]
        public async Task<ActionResult<ReadingDto>> CreateReading([FromQuery] string sensorName)
        {
            try
            {
                var readingDto = await _readingService.CreateReading(sensorName);

                return Ok(readingDto);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
