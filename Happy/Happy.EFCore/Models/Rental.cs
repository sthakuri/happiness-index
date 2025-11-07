using System;
using System.Collections.Generic;

namespace Happy.EFCore.Models;

public partial class Rental
{
    public int RentalId { get; set; }

    public int NeighborhoodId { get; set; }

    public int MonthlyRental { get; set; }

    public virtual Neighborhood Neighborhood { get; set; } = null!;
}
