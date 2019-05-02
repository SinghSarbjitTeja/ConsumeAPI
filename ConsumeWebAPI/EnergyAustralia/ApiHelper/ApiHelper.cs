using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EnergyAustralia.ApiHelper
{
    public static class ApiHelper
    {
        private const string URL = "http://eacodingtest.digital.energyaustralia.com.au";

        // HTTP client object
        public static HttpClient ApiClient { get; set; }

        public static HttpClient InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return ApiClient;
        }
    }
}
