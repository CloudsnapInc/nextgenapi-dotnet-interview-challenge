using InterviewTestProject.Domain.Covid.ApiResponse;

namespace InterviewTestProject.Services;

public interface ICovidService
{
    Task<CovidApiResponseDto> fetchAllCountries();
    
}