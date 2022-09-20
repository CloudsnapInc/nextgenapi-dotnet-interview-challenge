using InterviewTestProject.Domain.Covid.ApiResponse;

namespace InterviewTestProject.Services.Resources;

public interface ICovidHttpClient
{
    public Task<CovidApiResponseDto> fetchSummary();
}