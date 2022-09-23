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
    
    public async Task<List<CovidApiResponseCountryDto>> FetchAllCountries()
    {
        var apiData = await _covidHttpClient.FetchSummary();
        return apiData.Countries;
    }

    public async Task<List<CovidApiResponseCountryDto>> FetchCountries()
    {
        /// TODO
        throw new NotImplementedException();
    }

}
