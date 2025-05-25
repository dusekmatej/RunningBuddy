using System.Text.Json.Serialization;

namespace RunningBuddy.Models;

public class ForecastList
{
    [JsonPropertyName("cod")]
    public string Cod { get; set; }

    [JsonPropertyName("message")]
    public int Message { get; set; }

    [JsonPropertyName("cnt")]
    public int Cnt { get; set; }

    [JsonPropertyName("list")]
    public List<ForecastEntry> List { get; set; }

    [JsonPropertyName("city")]
    public City City { get; set; }
}
