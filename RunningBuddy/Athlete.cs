using RunningBuddy.Preferences;

namespace RunningBuddy;

public class Athlete
{
    public bool? TempPref { get; set; }

    public int MinTemp { get; set; }
    public int MaxTemp { get; set; }
    public bool IsStormSuitable { get; set; } 
    public bool IsDrizzleSuitable { get; set; } 
    public bool IsRainSuitable { get; set; } 
    public bool IsSnowSuitable { get; set; }
    
    public bool WeatherSuitability { get; set; }
    public bool TemperatureSuitability { get; set; }
}