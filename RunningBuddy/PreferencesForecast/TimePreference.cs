using RunningBuddy.ModelsForecast;
using RunningBuddy.Services;

namespace RunningBuddy.PreferencesForecast;

public class TimePreference(ApiServiceForecast apiService) : UserPreferenceF(apiService)
{
    public override bool IsSatisfied(Athlete athlete, string city, ForecastEntry? currentEntry)
    {
        long sunriseInLocation = GetSunrise(city);
        long sunsetInLocation = GetSunset(city);
        
        TimeSpan sunrise = DateTimeOffset.FromUnixTimeSeconds(sunriseInLocation).UtcDateTime.TimeOfDay;
        TimeSpan sunset = DateTimeOffset.FromUnixTimeSeconds(sunsetInLocation).UtcDateTime.TimeOfDay;
        TimeSpan currentEntryTime = DateTimeOffset.FromUnixTimeSeconds(currentEntry.Dt).UtcDateTime.TimeOfDay;
        
        Logging.Log(city);
        Logging.Log($"Sunrise in location {sunriseInLocation}");
        Logging.Log($"Sunset in location {sunsetInLocation}");
        
        Logging.Log($"Sunrise in UTC {sunrise}");
        Logging.Log($"Sunset in UTC {sunset}");
        Logging.Log($"Entry in UTC {currentEntryTime}");
        
        if (sunrise <= currentEntryTime && sunset >= currentEntryTime)
            return true;

        return false;
    }
}