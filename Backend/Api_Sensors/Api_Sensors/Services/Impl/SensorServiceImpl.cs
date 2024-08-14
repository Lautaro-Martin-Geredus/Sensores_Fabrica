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

        public async Task<SensorDto> CreateSensor(SensorDto sensorDto)
        {
            return await _sensorRepository.PostSensor(sensorDto);
        }

        /*public Task<SensorDto> DeleteSensor(string name)
        {
            
        }

        public Task<SensorDto> EditSensor(SensorDto sensorDto)
        {
            
        }

        public Task<SensorDto> GetSensorByName(string name)
        {
            
        }*/

        public async Task<List<SensorDto>> GetSensorsAsync()
        {
            var sensors = await _sensorRepository.GetSensors();
            if(sensors == null)
            {
                throw new Exception("Sensors not found");
            }

            return sensors;
        }
    }
}
