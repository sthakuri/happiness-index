using System;
using System.Collections.Generic;

namespace Happy.EFCore.Models;

public partial class Population
{
    public int PopulationId { get; set; }

    public string ZipCode { get; set; } = null!;

    public int PopulationCount { get; set; }
}
