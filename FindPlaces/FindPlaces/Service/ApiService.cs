using FindPlaces.Contracts;
using FindPlaces.Helper;
using FindPlaces.Models;
using FindPlaces.Service;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ApiService))]
namespace FindPlaces.Service
{
    /// <summary>
    /// Api Service
    /// </summary>
    public class ApiService : IApiService
    {
        #region Fetch Data From API

        /// <summary>
        /// Fetch data from server.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <returns></returns>
        public async Task<Response> FetchData(string query)
        {
            var returnResult = new Response();

            HttpClient client = null;
            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.Timeout = new TimeSpan(0, 0, 15);

                var result = await client.GetAsync(new Uri(string.Format(Constants.PlaceApiHostURL, query, Constants.PlaceAppApiKey)));

                if (result != null)
                {
                    if (result.IsSuccessStatusCode
                                       && result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var json = result.Content.ReadAsStringAsync().Result;
                        returnResult = JsonConvert.DeserializeObject<Response>(json);
                    }
                }

            }
            catch (TaskCanceledException cancelExcpetiom)
            {
                //If task gets cancelled e.g. network is slow.
                returnResult.Message = cancelExcpetiom.Message;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error while fetching data: " + ex.Message);
                returnResult.Message = ex.Message;
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }

            return returnResult;
        }

        #endregion
    }
}
