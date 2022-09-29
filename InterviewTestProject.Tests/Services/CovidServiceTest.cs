using InterviewTestProject.Domain.Covid.ApiResponse;
using InterviewTestProject.Services;
using InterviewTestProject.Services.Resources;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace InterviewTestProject.Tests.Services
{

    public class CovidServiceTest
    {
        protected CovidApiResponseDto GenerateCountrySummaryMockData()
        {
            var ret = new CovidApiResponseDto()
            {
                Global = new CovidApiResponseGlobalDto()
                {
                    NewConfirmed = 100,
                    TotalConfirmed = 800,
                    NewDeaths = 20,
                    NewRecovered = 40,
                    TotalDeaths = 90,
                    TotalRecovered = 333
                },
                Countries = new List<CovidApiResponseCountryDto>()
            {
                new CovidApiResponseCountryDto()
                {
                    Country = "Wasteland",
                    CountryCode = "WL",
                    Slug = "waste-land",
                    NewConfirmed = 120,
                    TotalConfirmed = 8000,
                    NewDeaths = 80,
                    TotalDeaths = 100,
                    NewRecovered = 26,
                    TotalRecovered = 100,
                },
                new CovidApiResponseCountryDto()
                {
                    Country = "Opportunityland",
                    CountryCode = "OL",
                    Slug = "opportunity-land",
                    NewConfirmed = 15,
                    TotalConfirmed = 500,
                    NewDeaths = 5,
                    TotalDeaths = 0,
                    NewRecovered = 5,
                    TotalRecovered = 10,
                },
                new CovidApiResponseCountryDto()
                {
                    Country = "Midland",
                    CountryCode = "ML",
                    Slug = "mid-land",
                    NewConfirmed = 80,
                    TotalConfirmed = 3000,
                    NewDeaths = 10,
                    TotalDeaths = 50,
                    NewRecovered = 13,
                    TotalRecovered = 45,
                }
            }
            };
            return ret;
        }

        [Fact]
        public async Task TestFetchCountries_All()
        {
            /// arrange
            var mockCountries = GenerateCountrySummaryMockData();

            var httpClientMock = new Mock<ICovidHttpClient>();
            httpClientMock.Setup(p => p.FetchSummary()).ReturnsAsync(mockCountries);

            var covidService = new CovidService(httpClientMock.Object);

            /// act
            var result = await covidService.FetchAllCountries();

            /// assert
            Assert.Equal(3, result.Count);
            Assert.Equal("WL", result[0].CountryCode);
            Assert.Equal("OL", result[1].CountryCode);
            Assert.Equal("ML", result[2].CountryCode);
        }

        [Fact]
        public void TestFetchCountries_OffsetLimit()
        {
            //// TODO
        }



    }
}