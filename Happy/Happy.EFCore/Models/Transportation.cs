using System;
using System.Collections.Generic;

namespace Happy.EFCore.Models;

public partial class Transportation
{
    public int TransportationId { get; set; }

    public int NeighborhoodId { get; set; }

    public int MuniStops { get; set; }

    public decimal? Score { get; set; }

    public virtual Neighborhood Neighborhood { get; set; } = null!;
}
