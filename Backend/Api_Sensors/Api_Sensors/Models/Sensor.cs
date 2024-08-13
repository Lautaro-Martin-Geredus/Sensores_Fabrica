using System;
using System.Collections.Generic;

namespace Api_Sensors.Models;

public partial class Sensor
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Unit { get; set; } = null!;

    public virtual ICollection<Reading> Readings { get; set; } = new List<Reading>();
}
