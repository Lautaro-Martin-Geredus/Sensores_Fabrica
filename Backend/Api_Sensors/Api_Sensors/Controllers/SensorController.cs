using Api_Sensors.Dto.Sensor;
using Api_Sensors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Sensors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ISensorService _sensorService;

        public SensorController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpGet("GetSensors")]
        public async Task<ActionResult<List<SensorDto>>> GetSensors()
        {
            try
            {
                var sensors = await _sensorService.GetSensorsAsync();
                return Ok(sensors);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("CreateSensors")]
        public async Task<ActionResult<SensorDto>> CreateSensor([FromBody] SensorDto sensorDto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var resultDto = await _sensorService.CreateSensor(sensorDto);
                return Ok(resultDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetSensorByName")]
        public async Task<ActionResult<SensorDto>> GetSensorByName(string name)
        {
            try
            {
                var sensorName = await _sensorService.GetSensorByName(name);
                return Ok(sensorName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
