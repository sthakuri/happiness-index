using Happy.EFCore;
using Happy.Services.Interfaces;
using Happy.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Happy.Services
{
    public class RentalService(HappyDbContext dbContext): IRentalService
    {
        HappyDbContext HappyDb = dbContext;
        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllAsync()
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.Rentals)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    MonthlyRental = (int)x.SelectMany(x => x.Rentals).Average(x => x.MonthlyRental)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllByZipCodeAsync(string zipCode)
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.Rentals)
                .Where(x => x.ZipCode == zipCode)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    MonthlyRental = (int)x.SelectMany(x => x.Rentals).Average(x => x.MonthlyRental)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllByNeighborhoodAsync(string neighborhoodName)
        {
            return await HappyDb.Neighborhoods
                .Include(x => x.Rentals)
                .Where(x => x.NeighborhoodName == neighborhoodName)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key,
                    MonthlyRental = (int)x.SelectMany(x => x.Rentals).Average(x => x.MonthlyRental)
                })
                .ToListAsync();
        }
    }
}
