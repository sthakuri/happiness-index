using Happy.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Services.Interfaces
{
    public interface IPopulationService
    {
        /// <summary>
        /// Get population
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Population>> GetAllAsync();
        /// <summary>
        /// Get population by ZipCode
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        Task<IEnumerable<Population>> GetAllByZipCodeAsync(string zipCode);
    }
}
