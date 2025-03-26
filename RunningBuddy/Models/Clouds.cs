using System.Text.Json.Serialization;

namespace RunningBuddy.Models;

public class Clouds
{
    [JsonPropertyName("all")]
    public int All { get; set; }
}