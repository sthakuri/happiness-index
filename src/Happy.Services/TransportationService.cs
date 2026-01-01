using Happy.EFCore;
using Happy.Services.Interfaces;
using Happy.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Happy.Services
{
    public class TransportationService(HappyDbContext dbContext) : ITransportationService
    {
        HappyDbContext HappyDb = dbContext;
        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllAsync()
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.Transportations)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    MuniStops = x.SelectMany(x => x.Transportations).Sum(x => x.MuniStops)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllByZipCodeAsync(string zipCode)
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.Transportations)
                .Where(x => x.ZipCode == zipCode)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    MuniStops = x.SelectMany(x => x.Transportations).Sum(x => x.MuniStops)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllByNeighborhoodAsync(string neighborhoodName)
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.Transportations)
                .Where(x => x.NeighborhoodName == neighborhoodName)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    MuniStops = x.SelectMany(x => x.Transportations).Sum(x => x.MuniStops)
                })
                .ToListAsync();
        }
    }
}
