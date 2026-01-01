using System;
using System.Collections.Generic;

namespace Happy.EFCore.Models;

public partial class Income
{
    public int IncomeId { get; set; }

    public int NeighborhoodId { get; set; }

    public int MedianIncome { get; set; }

    public decimal? Score { get; set; }

    public virtual Neighborhood Neighborhood { get; set; } = null!;
}
