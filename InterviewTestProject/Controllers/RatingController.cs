using InterviewTestProject.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace InterviewTestProject.Controllers
{

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
        public async Task<IEnumerable<Rating>> Get(string info)
        {
            var connection = new SQLiteConnection("Data Source=database.db;Version=3;Compress=True;");
            connection.Open();

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = string.Format("SELECT Id, Rate, Info FROM Ratings WHERE Info LIKE '%{0}%'", info);
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
}