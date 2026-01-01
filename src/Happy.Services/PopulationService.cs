using Happy.EFCore;
using Happy.Services.Interfaces;
using Happy.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Happy.Services
{
    public class PopulationService(HappyDbContext dbContext) : IPopulationService
    {
        HappyDbContext HappyDb = dbContext;
        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllAsync()
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.Populations)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    Population = x.SelectMany(x => x.Populations).Sum(x => x.PopulationCount)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllByZipCodeAsync(string zipCode)
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.Populations)
                .Where(x => x.ZipCode == zipCode)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    Population = x.SelectMany(x => x.Populations).Sum(x => x.PopulationCount)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllByNeighborhoodAsync(string neighborhoodName)
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.Populations)
                .Where(x => x.NeighborhoodName == neighborhoodName)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    Population = x.SelectMany(x => x.Populations).Sum(x => x.PopulationCount)
                })
                .ToListAsync();
        }
    }
}
