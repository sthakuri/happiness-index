using System;
using System.Collections.Generic;

namespace Happy.EFCore.Models;

public partial class Neighborhood
{
    public int NeighborhoodId { get; set; }

    public string ZipCode { get; set; } = null!;

    public string NeighborhoodName { get; set; } = null!;

    public virtual ICollection<Population> Populations { get; set; } = new List<Population>();
}
