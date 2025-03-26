using System.Text.Json.Serialization;

namespace RunningBuddy.Models;

public class Wind
{
    [JsonPropertyName("speed")]
    public double Speed { get; set; }

    [JsonPropertyName("deg")]
    public int Deg { get; set; }

    [JsonPropertyName("gust")]
    public double? Gust { get; set; } // Nullable because gust might not always be present
}