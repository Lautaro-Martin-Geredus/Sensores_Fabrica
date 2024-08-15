namespace Api_Sensors.Dto.Sensor
{
    public class UpdateSensorDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Unit { get; set; } 
    }
}
