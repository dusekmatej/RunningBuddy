using RunningBuddy.Preferences;

namespace RunningBuddy;

public class Athlete
{
    public string athleteName { get; set; }
    
    public WeatherPreference WeatherPref { get; set; }
    public TemperaturePreference TempPref { get; set; }
    public TimePreference TimePref { get; set; }

    public int MinTemp { get; set; }
    public int MaxTemp { get; set; }
    
    public bool IsStormSuitable { get; set; } 
    public bool IsDrizzleSuitable { get; set; } 
    public bool IsRainSuitable { get; set; } 
    public bool IsSnowSuitable { get; set; }

    public Athlete(string name)
    {
        athleteName = name;
    }
}