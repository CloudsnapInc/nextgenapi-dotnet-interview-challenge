using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using InterviewTestProject.Domain.Covid.QueryParameters;
using InterviewTestProject.Domain.Covid.QueryResponse;
using InterviewTestProject.Services;

namespace InterviewTestProject.Controllers;

[ApiController]
[Route("covid")]
public class CovidController : ControllerBase
{
    private readonly ILogger<CovidController> _logger;
    private readonly IMapper _mapper;    
    private readonly ICovidService _covidService;    

    public CovidController(
        ILogger<CovidController> logger, 
        IMapper mapper,
        ICovidService covidService)
    {
        _logger = logger;
        _mapper = mapper;
        _covidService = covidService;
    }

    [HttpGet]
    public async Task<CovidQueryResponse> Get([FromQuery] CovidQueryParameters parameters)
    {
        var allCountries = await _covidService.fetchAllCountries();
        
        var countries = _mapper.Map<List<CovidQueryCountryResponse>>(allCountries.Countries);
        
        return new CovidQueryResponse(parameters, countries);
    }
}