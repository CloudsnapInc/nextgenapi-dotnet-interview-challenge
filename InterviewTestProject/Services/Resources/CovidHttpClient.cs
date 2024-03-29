using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using InterviewTestProject.Domain.Covid.ApiResponse;

namespace InterviewTestProject.Services.Resources
{

    public class CovidHttpClient : ICovidHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;

        public CovidHttpClient(
            IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;

            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<CovidApiResponseDto> FetchSummary()
        {
            var httpClient = _httpClientFactory.CreateClient();

            using var response = await httpClient.GetAsync("https://api.covid19api.com/summary", HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            var countries = await JsonSerializer.DeserializeAsync<CovidApiResponseDto>(stream, _options);

            if (countries is null)
            {
                throw new FormatException("Cannot parse data from COVID API");
            }

            return countries;
        }


    }
}