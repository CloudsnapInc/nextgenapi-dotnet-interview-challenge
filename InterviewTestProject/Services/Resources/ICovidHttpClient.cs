using InterviewTestProject.Domain.Covid.ApiResponse;
using System.Threading.Tasks;

namespace InterviewTestProject.Services.Resources
{

    public interface ICovidHttpClient
    {
        Task<CovidApiResponseDto> FetchSummary();
    }
}