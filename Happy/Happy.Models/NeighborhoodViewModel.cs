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
        public int Population { get; set; }
        public int MedianIncome { get; set; }
        public int CrimeIncident { get; set; }
        public int MonthlyRental { get; set; }
        public int ParkAndFacility { get; set; }
        public int MuniStops { get; set; }

        public decimal EconomicScore { get; set; }
        public decimal SafetyScore { get; set; }
        public decimal EnvironmentScore { get; set; }
        public decimal AccessibilityScore { get; set; }

        public decimal HappinessScore { get { return 0.30m *EconomicScore + 0.25m * SafetyScore + 0.20m * EnvironmentScore + 0.15m * AccessibilityScore; } }
    }
}
