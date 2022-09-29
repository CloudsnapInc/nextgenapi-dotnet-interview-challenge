using InterviewTestProject.Domain.Covid.ApiResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTestProject.Services
{

    public interface ICovidService
    {
        Task<List<CovidApiResponseCountryDto>> FetchAllCountries();

    }
}