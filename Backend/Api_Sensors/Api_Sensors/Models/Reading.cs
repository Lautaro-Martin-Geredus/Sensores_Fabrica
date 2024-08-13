using System;
using System.Collections.Generic;

namespace Api_Sensors.Models;

public partial class Reading
{
    public Guid Id { get; set; }

    public Guid SensorId { get; set; }

    public DateOnly ReadingDate { get; set; }

    public double Value { get; set; }

    public virtual Sensor Sensor { get; set; } = null!;
}
