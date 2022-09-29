using InterviewTestProject.Domain.Covid.QueryParameters;
using System.Collections.Generic;

namespace InterviewTestProject.Domain.Covid.QueryResponse
{

    public class CovidQueryResponse
    {
        public CovidQueryParameters Parameters { get; }
        public List<CovidQueryCountryResponse> Countries { get; }

        public CovidQueryResponse(
                    CovidQueryParameters parameters,
                    List<CovidQueryCountryResponse> countries
        )
        {
            this.Parameters = parameters;
            this.Countries = countries;
        }

    }
}