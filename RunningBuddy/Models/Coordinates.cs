using System.Text.Json.Serialization;

namespace RunningBuddy.Models;

public class Coordinates
{
    [JsonPropertyName("lon")]
    public double Lon { get; set; }

    [JsonPropertyName("lat")]
    public double Lat { get; set; }
}