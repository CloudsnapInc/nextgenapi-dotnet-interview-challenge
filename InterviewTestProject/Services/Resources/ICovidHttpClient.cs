using InterviewTestProject.Domain.Covid.ApiResponse;

namespace InterviewTestProject.Services.Resources;

public interface ICovidHttpClient
{
     Task<CovidApiResponseDto> FetchSummary();
}