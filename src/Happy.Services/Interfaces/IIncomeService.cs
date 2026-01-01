using Happy.ViewModels;

namespace Happy.Services.Interfaces
{
    public interface IIncomeService
    {
        /// <summary>
        /// Get Income
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<NeighborhoodViewModel>> GetAllAsync();
        /// <summary>
        /// Get Income by ZipCode
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        Task<IEnumerable<NeighborhoodViewModel>> GetAllByZipCodeAsync(string zipCode);
        /// <summary>
        /// Get Income by Neighborhood Name
        /// </summary>
        /// <param name="neighborhoodName"></param>
        /// <returns></returns>
        Task<IEnumerable<NeighborhoodViewModel>> GetAllByNeighborhoodAsync(string neighborhoodName);
    }
}
