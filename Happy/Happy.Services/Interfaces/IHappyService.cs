using Happy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Services.Interfaces
{
    public interface IHappyService
    {
        Task<IEnumerable<NeighborhoodViewModel>> GetNeighborhoodHappinessScoreAsync();
        Task<IEnumerable<NeighborhoodViewModel>> GetNeighborhoodHappinessScoreByZipCodeAsync(string zipCode);
        Task<IEnumerable<NeighborhoodViewModel>> GetNeighborhoodHappinessScoreByNameAsync(string neighborhoodName);
    }
}
