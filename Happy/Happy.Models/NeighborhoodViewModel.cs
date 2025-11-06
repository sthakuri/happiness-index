using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.ViewModels
{
    public class NeighborhoodViewModel
    {
        public int NeighborhoodId { get; set; }

        public string ZipCode { get; set; } = null!;

        public string NeighborhoodName { get; set; } = null!;
        public int PopulationCount { get; set; }
    }
}
