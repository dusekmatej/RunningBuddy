using System.Text.Json.Serialization;

namespace RunningBuddy.Models;

public class Sys
{
    [JsonPropertyName("type")]
    public int? Type { get; set; } // Nullable as not always included

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("sunrise")]
    public long Sunrise { get; set; }

    [JsonPropertyName("sunset")]
    public long Sunset { get; set; }
}