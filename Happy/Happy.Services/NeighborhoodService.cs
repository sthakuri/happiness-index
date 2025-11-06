using Happy.EFCore;
using Happy.EFCore.Models;
using Happy.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Services
{
    public class NeighborhoodService(HappyDbContext dbContext) : INeighborhoodService
    {
        HappyDbContext HappyDb = dbContext;
        public async Task<IEnumerable<Neighborhood>> GetAllAsync()
        {
            return await HappyDb.Neighborhoods
                .ToListAsync();
        }

        public async Task<IEnumerable<Neighborhood>> GetAllByZipCodeAsync(string zipCode)
        {
            return await HappyDb.Neighborhoods
                .Where(x=> x.ZipCode == zipCode)
                .ToListAsync();
        }
    }
}
