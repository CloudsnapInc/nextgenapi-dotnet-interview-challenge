using InterviewTestProject.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Data.SQLite;

namespace InterviewTestProject.Controllers;

[ApiController]
[Route("ratings")]
public class RatingController : ControllerBase
{
    private readonly ILogger<RatingController> _logger;

    public RatingController(ILogger<RatingController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<Rating>> Get(int minRate)
    {
        var connection = new SQLiteConnection("Data Source=database.db;Version=3;Compress=True;");
        connection.Open();

        SQLiteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Rate, Info FROM Ratings WHERE Rate >= " + minRate.ToString();
        DbDataReader reader = command.ExecuteReader();

        var response = new List<Rating>();

        while (reader.Read())
        {
            response.Add(new Rating()
            {
                Id = (long)reader["Id"],
                Rate = (int)reader["Rate"],
                Info = reader["Info"].ToString()
            });
        }

        return response;
    }
}