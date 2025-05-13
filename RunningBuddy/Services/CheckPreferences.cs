using RunningBuddy.Preferences;

namespace RunningBuddy.Services;

public class CheckPreferences
{
    
    // This class is responsible for checking the preferences of the athletes
    public CheckPreferences(Athlete athlete0, Athlete athlete1)
    {
        if (athlete0.WeatherSuitability != null && athlete1.WeatherSuitability != null)
        {
            if (athlete0.WeatherSuitability && athlete1.WeatherSuitability)
            {
            }
        }
            
    }
}