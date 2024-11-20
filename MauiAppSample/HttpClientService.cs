using System;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using static MauiAppSample.Utility.Constants;

namespace MauiAppSample
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        // Constructor to initialize HttpClient
        public HttpClientService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ServicesUrl.BaseUrl)
            };

            // Default headers
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode(); // Throw if not a success code.
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<T> GetAsync<T>(string endpoint, string authorizationToken = null)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_httpClient.BaseAddress, endpoint)
            };

            if (!string.IsNullOrWhiteSpace(authorizationToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authorizationToken);
            }

            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode(); // Throw if not a success code.
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
