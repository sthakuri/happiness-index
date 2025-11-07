using Happy.EFCore.Models;

namespace Happy.Services.Interfaces
{
    public interface INeighborhoodService
    {
        /// <summary>
        /// Get all neighborhoods
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Neighborhood>> GetAllAsync();
        /// <summary>
        /// Get neighborhoods by ZipCode
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        Task<IEnumerable<Neighborhood>> GetAllByZipCodeAsync(string zipCode);
    }
}
