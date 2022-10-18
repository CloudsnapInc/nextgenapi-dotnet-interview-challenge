using InterviewTestProject.Domain.Covid.ApiResponse;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace InterviewTestProject.Services.Resources
{
    public class MockCovidHttpClient : ICovidHttpClient
    {
        private readonly JsonSerializerOptions _options;

        public MockCovidHttpClient()
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<CovidApiResponseDto> FetchSummary()
        {
            var stream = File.OpenRead("mockdata.json");
            var countries = await JsonSerializer.DeserializeAsync<CovidApiResponseDto>(stream, _options);

            if (countries is null)
                throw new FormatException("Cannot parse data from COVID API");

            return countries;
        }
    }
}