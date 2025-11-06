using Happy.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
