using System.Text.Json.Serialization;

namespace RunningBuddy.ModelsForecast;

public class Rain
{
    [JsonPropertyName("3h")]
    public double _3h { get; set; }
}