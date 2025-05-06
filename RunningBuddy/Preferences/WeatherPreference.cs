using System.Dynamic;
using RunningBuddy.Services;
using RunningBuddy.Models;

namespace RunningBuddy.Preferences;

public class WeatherPreference : IUserPreference
{
    private static ApiService? _apiService;
    private ApiList? _data;
    
    public WeatherPreference(ApiService apiService)
    {
        _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
    }

    public int GetId()
    {
        _data = _apiService.GetData("Hradec Kralove");
        var weather = _data.Weather[0];
        var returnValue = weather.Id;
        
        return returnValue;
    }
    
    public bool? IsSatisfied(Athlete athlete)
    {
        int weatherId = GetId();
        
        // 204 > 200 && 204 < 300 &&& IsStormSuitable
        if ((weatherId >= 200 && weatherId < 300) && athlete.IsStormSuitable)
            return true;
        else if ((weatherId <= 300 && weatherId < 400) && athlete.IsDrizzleSuitable)
            return true;
        else if (weatherId <= 500 && weatherId < 600 && athlete.IsRainSuitable)
            return true;
        else if (weatherId <= 600 && weatherId > 700 && athlete.IsSnowSuitable)
            return true;
        else if (weatherId == 800)
            return true;
        else if (weatherId > 800)
            return false;
        
        return null;
    }
}