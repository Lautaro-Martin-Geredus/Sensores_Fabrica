using Api_Sensors.Dto.Sensor;

namespace Api_Sensors.Services
{
    public interface ISensorService
    {
        Task<List<SensorDto>> GetSensorsAsync();

        Task<SensorDto> CreateSensor(SensorDto sensorDto);

        Task<SensorDto> GetSensorByName(string name);

        Task<SensorDto> EditSensor(string name, SensorDto sensorDto);

        Task<bool> DeleteSensor(string name);
    }
}
