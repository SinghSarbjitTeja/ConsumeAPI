using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnergyAustralia.Models;
using EnergyAustralia.Domain.Contracts;
using System.Net.Http;
using Newtonsoft.Json;


namespace EnergyAustralia.Domain.Services
{
    public class CarShowService : ICarShowService
    {
        private readonly HttpClient _httpClient;

        public CarShowService()
        {
            _httpClient = ApiHelper.ApiHelper.InitializeClient();
        }

        public async Task<IEnumerable<CarShow>> GetCarShows()
        {
            using (var response = await _httpClient.GetAsync("api/v1/cars", HttpCompletionOption.ResponseHeadersRead))
            {
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<CarShow>>(data);
                }
                throw new Exception(response.ReasonPhrase);
            }

        }
    }
}

