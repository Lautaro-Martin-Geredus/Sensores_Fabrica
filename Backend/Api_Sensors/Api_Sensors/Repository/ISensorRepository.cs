using Api_Sensors.Dto.Sensor;

namespace Api_Sensors.Repository
{
    public interface ISensorRepository
    {
        Task<List<SensorDto>> GetSensors();

        Task<SensorDto> PostSensor(SensorDto sensorDto);

        Task<SensorDto> GetSensorByName(string name);

        Task<SensorDto> PutSensor(Guid id, SensorDto sensorDto);
    }
}
