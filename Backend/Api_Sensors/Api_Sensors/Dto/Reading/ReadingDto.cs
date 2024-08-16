using Api_Sensors.Dto.Sensor;

namespace Api_Sensors.Dto.Reading
{
    public class ReadingDto
    {
        public string SensorName{ get; set; }

        public DateOnly ReadingDate { get; set; }

        public double Value { get; set; }
    }
}
