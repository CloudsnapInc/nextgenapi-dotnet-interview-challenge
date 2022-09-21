using System.Text.Json;
using InterviewTestProject.Domain.Covid.ApiResponse;
using InterviewTestProject.Services.Resources;

namespace InterviewTestProject.Services;

public class CovidService : ICovidService
{
    private readonly ICovidHttpClient _covidHttpClient;
    private readonly JsonSerializerOptions _options;
    
    public CovidService(
        ICovidHttpClient covidHttpClient)
    {
        this._covidHttpClient = covidHttpClient;
        
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
    
    public async Task<CovidApiResponseDto> fetchAllCountries()
    {
        return await _covidHttpClient.fetchSummary();
    }

    public async Task<List<CovidApiResponseCountryDto>> fetchCountriesByTask()
    {
        /// TODO
        throw new NotImplementedException();
    }

}
