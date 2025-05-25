namespace RunningBuddy;

public class Athlete
{
    public string? Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? Location { get; set; }
    
    public int MinTemp { get; set; }
    public int MaxTemp { get; set; }
    
    
    public bool IsStormSuitable { get; set; } 
    public bool IsDrizzleSuitable { get; set; } 
    public bool IsRainSuitable { get; set; } 
    public bool IsSnowSuitable { get; set; }
    public bool IsClearSuitable { get; set; }
    public bool IsCloudySuitable { get; set; }
    public bool IsAtmosphereSuitable { get; set; }
    public bool IsExtremeSuitable { get; set; }
    
    public bool WeatherSuitability { get; set; }
    public bool TemperatureSuitability { get; set; }
    
    public bool TimeSuitability { get; set; }

    // Constructor for object athlete
    public Athlete(string id)
    {
        Id = id;
    }
}