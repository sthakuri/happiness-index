using System;
using System.Collections.Generic;

namespace Happy.EFCore.Models;

public partial class Population
{
    public int PopulationId { get; set; }

    public int NeighborhoodId { get; set; }

    public int PopulationCount { get; set; }

    public virtual Neighborhood Neighborhood { get; set; } = null!;
}
