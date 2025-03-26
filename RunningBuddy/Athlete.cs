namespace RunningBuddy;

public class Athlete
{
    public int minTemp { get; set; }
    public int maxTemp { get; set; }
    
    public bool isStormSuitable { get; set; } 
    public bool isDrizzleSuitable { get; set; } 
    public bool isRainSuitable { get; set; } 
    public bool isSnowSuitable { get; set; } 
}