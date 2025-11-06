using Happy.EFCore;
using Happy.EFCore.Models;
using Happy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Services
{
    public class PopulationService(HappyDbContext dbContext) : IPopulationService
    {
        HappyDbContext HappyDb = dbContext;
        public async Task<IEnumerable<Population>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Population>> GetAllByZipCodeAsync(string zipCode)
        {
            throw new NotImplementedException();
        }
    }
}
