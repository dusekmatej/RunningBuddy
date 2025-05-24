using RunningBuddy.ModelsForecast;
using RunningBuddy.Services;

namespace RunningBuddy.PreferencesForecast;

public class TempPreferenceF(ApiServiceForecast apiService) : UserPreferenceF(apiService)
{
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