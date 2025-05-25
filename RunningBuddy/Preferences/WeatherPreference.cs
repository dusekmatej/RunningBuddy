using RunningBuddy.Models;
using RunningBuddy.Services;

namespace RunningBuddy.Preferences;

public class WeatherPreference(ApiServiceForecast apiService) : UserPreference(apiService)
{
    
    // This preference checks if the athlete's weather suitability matches the current weather conditions.
    public override bool IsSatisfied(Athlete athlete, string city, ForecastEntry? currentEntry)
    {
        if (currentEntry?.Weather == null || currentEntry.Weather.Count == 0)
        {
            Logging.Log("Weather currentEntry is null or empty");
        }
        
        int currentWeatherId = currentEntry.Weather[0].Id;
        Logging.Log($"ID for this entry {currentEntry.DtTxt} is {currentWeatherId}");
        
        switch (currentWeatherId)
        {
            // Thunderstorm: 200–299
            case >= 200 and < 300 when athlete.IsStormSuitable:
                return true;

            // Drizzle: 300–399
            case >= 300 and < 400 when athlete.IsDrizzleSuitable:
                return true;

            // Rain: 500–599
            case >= 500 and < 600 when athlete.IsRainSuitable:
                return true;

            // Snow: 600–699
            case >= 600 and < 700 when athlete.IsSnowSuitable:
                return true;

            // Atmosphere (mist, smoke, fog, etc.): 700–799
            case >= 700 and < 800 when athlete.IsAtmosphereSuitable:
                return true;

            // Clear sky
            case 800 when athlete.IsClearSuitable:
                return true;

            // Cloudy (few to overcast clouds): 801–804
            case >= 801 and <= 804 when athlete.IsCloudySuitable:
                Logging.Log("Cloudy weather case");
                return true;

            // Extreme weather (tornado, hurricane, etc.): 900–906
            case >= 900 and <= 906 when athlete.IsExtremeSuitable:
                return true;
            
            default: return false;
        }
        
    }
}