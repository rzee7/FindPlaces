using FindPlaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPlaces.Contracts
{
    /// <summary>
    /// IApi Service
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// Fetch data from server.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <returns></returns>
        Task<Response> FetchData(string query);
    }
}
