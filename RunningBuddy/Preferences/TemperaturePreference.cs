using RunningBuddy.Models;
using RunningBuddy.Services;

namespace RunningBuddy.Preferences;

public class TemperaturePreference(ApiServiceForecast apiService) : UserPreference(apiService)
{
    // Checks if current temperature is within the athlete's preferred range
    public override bool IsSatisfied(Athlete athlete, string city, ForecastEntry? currentEntry)
    {
        var currentTemp = currentEntry.Main.Temp;
        
        if (currentTemp >= athlete.MinTemp && currentTemp <= athlete.MaxTemp)
        {
            Logging.Log($"Current entry: {currentEntry.DtTxt} Current Temp: {currentTemp}");
            return true;
        }

        return false;
    }
}