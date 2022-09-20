namespace InterviewTestProject.Domain.Covid.ApiResponse;

public class CovidApiResponseDto
{
    public CovidApiResponseGlobalDto Global { get; set; }
    public List<CovidApiResponseCountryDto> Countries { get; set; }
}