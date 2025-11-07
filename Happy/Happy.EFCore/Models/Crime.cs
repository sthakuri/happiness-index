using System;
using System.Collections.Generic;

namespace Happy.EFCore.Models;

public partial class Crime
{
    public int CrimeId { get; set; }

    public int NeighborhoodId { get; set; }

    public int IncidentCount { get; set; }

    public virtual Neighborhood Neighborhood { get; set; } = null!;
}
