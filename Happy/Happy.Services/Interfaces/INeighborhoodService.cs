using Happy.EFCore.Models;
using Happy.ViewModels;

namespace Happy.Services.Interfaces
{
    public interface INeighborhoodService
    {
        /// <summary>
        /// Get all neighborhoods
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<NeighborhoodViewModel>> GetAllAsync();
        /// <summary>
        /// Get neighborhoods by ZipCode
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        Task<IEnumerable<NeighborhoodViewModel>> GetAllByZipCodeAsync(string zipCode);
    }
}
