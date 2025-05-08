using System.Diagnostics;
using RunningBuddy.Services;
using RunningBuddy.Models;

namespace RunningBuddy.Preferences;

public class WeatherPreference : UserPreference
{
    public WeatherPreference(ApiService apiService) : base(apiService)
    {
    }

    public override bool? IsSatisfied(Athlete athlete)
    {
        int weatherId = GetId();
        Debug.WriteLine($"GetID = {GetId()} --------------------------");
        
        // Better future implementation make two arrays/lists and cycle through those items not
        // sure if it is possible just a thought
        
        // 204 > 200 && 204 < 300 &&& IsStormSuitable
        if ((weatherId >= 200 && weatherId < 300) && athlete.IsStormSuitable)
            return true;
        else if ((weatherId <= 300 && weatherId < 400) && athlete.IsDrizzleSuitable)
            return true;
        else if (weatherId <= 500 && weatherId < 600 && athlete.IsRainSuitable)
            return true;
        else if (weatherId <= 600 && weatherId > 700 && athlete.IsSnowSuitable)
            return true;
        else if (weatherId == 800 )
            return true;
        else if (weatherId > 800 && weatherId < 900 & athlete.IsSnowSuitable)
            return true;
        
        return false;
    }
}