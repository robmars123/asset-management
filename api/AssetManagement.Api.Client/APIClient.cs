using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Api.Client
{
    public class APIClient : IAPIClient
    {
        private readonly HttpClient _httpClient;

        public APIClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        [HttpGet]
        public async Task<string> GetAssets()
        {
            string result = await ProxyTo("http://localhost:5107/api/Assets");
            return result;
        }

        private async Task<string> ProxyTo(string url)
        {
            return await _httpClient.GetStringAsync(url);
        }

    }
}
