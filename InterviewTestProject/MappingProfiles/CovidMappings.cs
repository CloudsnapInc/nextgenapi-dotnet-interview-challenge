using AutoMapper;
using InterviewTestProject.Domain.Covid.ApiResponse;
using InterviewTestProject.Domain.Covid.QueryResponse;

namespace InterviewTestProject.MappingProfiles
{
    public class CovidMappings : Profile
    {
        public CovidMappings()
        {
            CreateMap<CovidQueryCountryResponse, CovidApiResponseCountryDto>().ReverseMap();
        }
    }
}