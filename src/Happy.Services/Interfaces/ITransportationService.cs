using Happy.ViewModels;

namespace Happy.Services.Interfaces
{
    public interface ITransportationService
    {
        /// <summary>
        /// Get All Muni Stops
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<NeighborhoodViewModel>> GetAllAsync();
        /// <summary>
        /// Get Muni Stops by ZipCode
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        Task<IEnumerable<NeighborhoodViewModel>> GetAllByZipCodeAsync(string zipCode);
        /// <summary>
        /// Get Muni Stops by Neighborhood Name
        /// </summary>
        /// <param name="neighborhoodName"></param>
        /// <returns></returns>
        Task<IEnumerable<NeighborhoodViewModel>> GetAllByNeighborhoodAsync(string neighborhoodName);
    }
}
