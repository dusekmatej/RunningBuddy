using System.Diagnostics;
using RunningBuddy.Services;
using RunningBuddy.Models;

namespace RunningBuddy.Preferences;

public class WeatherPreference(ApiService apiService) : UserPreference(apiService)
{
    public override bool IsSatisfied(Athlete athlete)
    {
        int weatherId = GetId();
        Debug.WriteLine($"GetID = {GetId()} --------------------------");
        
        // Better future implementation make two arrays/lists and cycle through those items not
        // sure if it is possible just a thought
        
        // 204 > 200 && 204 < 300 &&& IsStormSuitable
        
        return weatherId switch
        {
            >= 200 and < 300 when athlete.IsStormSuitable => true,
            >= 300 and < 400 when athlete.IsDrizzleSuitable => true,
            >= 500 and < 600 when athlete.IsRainSuitable => true,
            >= 600 and < 700 when athlete.IsSnowSuitable => true,
            800 => true,
            > 800 and < 900 when athlete.IsSnowSuitable => true,
            _ => false
        };
    }
}