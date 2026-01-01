using Happy.ViewModels;

namespace Happy.Services.Interfaces
{
    public interface IPopulationService
    {
        /// <summary>
        /// Get population
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<NeighborhoodViewModel>> GetAllAsync();
        /// <summary>
        /// Get population by ZipCode
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        Task<IEnumerable<NeighborhoodViewModel>> GetAllByZipCodeAsync(string zipCode);
        /// <summary>
        /// Get population by Neighborhood Name
        /// </summary>
        /// <param name="neighborhoodName"></param>
        /// <returns></returns>
        Task<IEnumerable<NeighborhoodViewModel>> GetAllByNeighborhoodAsync(string neighborhoodName);
    }
}
