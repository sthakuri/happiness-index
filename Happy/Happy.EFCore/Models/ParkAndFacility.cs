using System;
using System.Collections.Generic;

namespace Happy.EFCore.Models;

public partial class ParkAndFacility
{
    public int ParkAndFacilityId { get; set; }

    public int NeighborhoodId { get; set; }

    public int FacilityCount { get; set; }

    public decimal? Score { get; set; }

    public virtual Neighborhood Neighborhood { get; set; } = null!;
}
