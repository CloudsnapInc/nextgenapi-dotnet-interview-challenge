using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InterviewTestProject.Domain.Covid.QueryParameters;

public class CovidQueryParameters
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderType
    {
        [EnumMember(Value = "ASC")]
        ASC,
        [EnumMember(Value = "DESC")]
        DESC
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ByType
    {
        [EnumMember(Value = "Country")]
        country,
        [EnumMember(Value = "NewConfirmed")]
        newConfirmed,
        [EnumMember(Value = "TotalConfirmed")]
        totalConfirmed,
    }
    
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 100;
    public OrderType? Order { get; set; }
    public ByType? By { get; set; }
}