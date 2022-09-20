using InterviewTestProject.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;

namespace InterviewTestProject.Controllers;

[ApiController]
[Route("codereviews")]
public class CodeReviewController : ControllerBase
{
    private readonly ILogger<CodeReviewController> _logger;

    public CodeReviewController(ILogger<CodeReviewController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<CodeReview>> Get()
    {
        var connection = new SQLiteConnection("Data Source=database.db;Version=3;Compress=True;");
        connection.Open();

        SQLiteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Rate, Info FROM CodeReviews";
        SQLiteDataReader reader = command.ExecuteReader();

        var response = new List<CodeReview>();

        while (reader.Read())
        {
            response.Add(new CodeReview()
            {
                Id = (long)reader["Id"],
                Rate = (int)reader["Rate"],
                Info = reader["Info"].ToString()
            });
        }

        connection.Close();

        return response;
    }
}