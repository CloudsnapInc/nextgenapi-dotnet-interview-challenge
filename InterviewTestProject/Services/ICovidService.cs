using InterviewTestProject.Domain.Covid.ApiResponse;

namespace InterviewTestProject.Services;

public interface ICovidService
{
    public Task<CovidApiResponseDto> fetchAllCountries();
    
}