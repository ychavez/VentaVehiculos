using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace VentaVehiculos.Context
{
    public class RestService
    {
        HttpClient _client;
        Uri _UrlBase;

        public RestService()
        {
            _UrlBase = new Uri(Constants.ServiceConstants.BaseUrl);
            _client = new HttpClient();
            _client.BaseAddress = _UrlBase;
        }

        
        public async Task<List<T>> GetDataAsync<T>(string url) 
        {
            List<T> TData = null;

            try
            {
                var response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    TData = JsonConvert.DeserializeObject<List<T>>(content);
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Error {ex.Message}");
            }

            return TData;
        }
    }
}
