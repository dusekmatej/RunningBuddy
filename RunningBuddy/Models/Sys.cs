using System.Text.Json.Serialization;

namespace RunningBuddy.Models;

public class Sys
{
    public string Pod { get; set; }
    
    [JsonPropertyName("sunrise")]
    public long Sunrise { get; set; }

    [JsonPropertyName("sunset")]
    public long Sunset { get; set; }
}