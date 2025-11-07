using Happy.EFCore;
using Happy.Services.Interfaces;
using Happy.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Happy.Services
{
    public class ParkAndFacilityService(HappyDbContext dbContext) : IParkAndFacilityService
    {
        HappyDbContext HappyDb = dbContext;
        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllAsync()
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.ParkAndFacilities)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    ParkAndFacility = x.SelectMany(x => x.ParkAndFacilities).Sum(x => x.FacilityCount)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllByZipCodeAsync(string zipCode)
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.ParkAndFacilities)
                .Where(x => x.ZipCode == zipCode)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    ParkAndFacility = x.SelectMany(x => x.ParkAndFacilities).Sum(x => x.FacilityCount)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllByNeighborhoodAsync(string neighborhoodName)
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.ParkAndFacilities)
                .Where(x => x.NeighborhoodName == neighborhoodName)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    ParkAndFacility = x.SelectMany(x => x.ParkAndFacilities).Sum(x => x.FacilityCount)
                })
                .ToListAsync();
        }
    }
}
