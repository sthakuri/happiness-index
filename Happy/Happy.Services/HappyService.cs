using Happy.EFCore;
using Happy.Services.Interfaces;
using Happy.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Services
{
    public class HappyService(HappyDbContext happyDbContext) : IHappyService
    {
        HappyDbContext HappyDb = happyDbContext;
        public async Task<IEnumerable<NeighborhoodViewModel>> GetNeighborhoodHappinessScoreAsync()
        {
            return await HappyDb.Neighborhoods
                .Include(x=> x.Populations)
                .Include(x => x.Incomes)
                .Include(x => x.Rentals)
                .Include(x => x.Crimes)
                .Include(x => x.ParkAndFacilities)
                .Include(x => x.Transportations)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    Population = x.SelectMany(x=> x.Populations).Sum(x=> x.PopulationCount),
                    // Economic Score->Income & Employment + Housing & Rent
                    EconomicScore = (x.SelectMany(x => x.Incomes).Average(x => x.Score!.Value) + x.SelectMany(x => x.Rentals).Average(x => x.Score!.Value)) / 2,
                    // Safety Score -> Safety & Crime
                    SafetyScore = x.SelectMany(x => x.Crimes).Average(x => x.Score!.Value),
                    // Environment Score -> Recreation & Park
                    EnvironmentScore = x.SelectMany(x => x.ParkAndFacilities).Average(x => x.Score!.Value),
                    // Accessibility Score -> Commute & Transportation
                    AccessibilityScore = x.SelectMany(x => x.Transportations).Average(x => x.Score!.Value)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetNeighborhoodHappinessScoreByNameAsync(string zipCode)
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.Incomes)
                .Include(x => x.Rentals)
                .Include(x => x.Crimes)
                .Include(x => x.ParkAndFacilities)
                .Include(x => x.Transportations)
                .Where(x => x.ZipCode == zipCode)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    // Economic Score->Income & Employment + Housing & Rent
                    EconomicScore = (x.SelectMany(x => x.Incomes).Average(x => x.Score!.Value) + x.SelectMany(x => x.Rentals).Average(x => x.Score!.Value)) / 2,
                    // Safety Score -> Safety & Crime
                    SafetyScore = x.SelectMany(x => x.Crimes).Average(x => x.Score!.Value),
                    // Environment Score -> Recreation & Park
                    EnvironmentScore = x.SelectMany(x => x.ParkAndFacilities).Average(x => x.Score!.Value),
                    // Accessibility Score -> Commute & Transportation
                    AccessibilityScore = x.SelectMany(x => x.Transportations).Average(x => x.Score!.Value)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetNeighborhoodHappinessScoreByZipCodeAsync(string neighborhoodName)
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.Incomes)
                .Include(x => x.Rentals)
                .Include(x => x.Crimes)
                .Include(x => x.ParkAndFacilities)
                .Include(x => x.Transportations)
                .Where(x => x.NeighborhoodName == neighborhoodName)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    // Economic Score->Income & Employment + Housing & Rent
                    EconomicScore = (x.SelectMany(x => x.Incomes).Average(x => x.Score!.Value) + x.SelectMany(x => x.Rentals).Average(x => x.Score!.Value)) / 2,
                    // Safety Score -> Safety & Crime
                    SafetyScore = x.SelectMany(x => x.Crimes).Average(x => x.Score!.Value),
                    // Environment Score -> Recreation & Park
                    EnvironmentScore = x.SelectMany(x => x.ParkAndFacilities).Average(x => x.Score!.Value),
                    // Accessibility Score -> Commute & Transportation
                    AccessibilityScore = x.SelectMany(x => x.Transportations).Average(x => x.Score!.Value)
                })
                .ToListAsync();
        }
    }
}
