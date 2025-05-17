using RunningBuddy.Services;

namespace RunningBuddy.Preferences;

public class TimePreference(ApiService apiService) : UserPreference(apiService)
{
    public override bool IsSatisfied(Athlete athlete, string city)
    {
        long sunriseUnix = GetSunrise(city);
        long sunsetUnix = GetSunset(city);
        
        DateTime sunrise = DateTimeOffset.FromUnixTimeSeconds(sunriseUnix).UtcDateTime;
        DateTime sunset = DateTimeOffset.FromUnixTimeSeconds(sunsetUnix).UtcDateTime;
        DateTime now = DateTime.UtcNow;
        
        Logging.Log($"{sunrise}");
        Logging.Log($"{sunset}");
        
        if (sunrise <= now && sunset >= now)
            return true;
        
        return false;
    }
}