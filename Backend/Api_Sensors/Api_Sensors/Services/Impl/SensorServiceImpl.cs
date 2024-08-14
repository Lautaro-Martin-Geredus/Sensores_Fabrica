using Api_Sensors.Dto.Sensor;
using Api_Sensors.Repository;

namespace Api_Sensors.Services.Impl
{
    public class SensorServiceImpl : ISensorService
    {
        private readonly ISensorRepository _sensorRepository;

        public SensorServiceImpl(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        public Task<SensorDto> CreateSensor(SensorDto sensorDto)
        {
            
        }

        public Task<SensorDto> DeleteSensor(string name)
        {
            
        }

        public Task<SensorDto> EditSensor(SensorDto sensorDto)
        {
            
        }

        public Task<SensorDto> GetSensorByName(string name)
        {
            
        }

        public Task<List<SensorDto>> GetSensorsAsync()
        {
            
        }
    }
}
