using Happy.EFCore;
using Happy.Services.Interfaces;
using Happy.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Happy.Services
{
    public class SafetyService(HappyDbContext dbContext): ISafetyService
    {
        HappyDbContext HappyDb = dbContext;
        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllAsync()
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.Crimes)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    CrimeIncident = x.SelectMany(x => x.Crimes).Sum(x => x.IncidentCount)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllByZipCodeAsync(string zipCode)
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.Crimes)
                .Where(x => x.ZipCode == zipCode)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    CrimeIncident = x.SelectMany(x => x.Crimes).Sum(x => x.IncidentCount)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllByNeighborhoodAsync(string neighborhoodName)
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.Crimes)
                .Where(x => x.NeighborhoodName == neighborhoodName)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    CrimeIncident = x.SelectMany(x => x.Crimes).Sum(x => x.IncidentCount)
                })
                .ToListAsync();
        }
    }
}
