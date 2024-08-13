using System;
using System.Collections.Generic;

namespace Api_Sensors.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Password { get; set; }

    public string? Description { get; set; }
}
