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
        if ((GetId() <= 200 && GetId() > 300) && athlete.IsStormSuitable)
        {
            return true;
        }
        else if ((GetId() <= 300 && GetId() > 400) && athlete.IsDrizzleSuitable)
        {
            return true;
        }
        else if (GetId() <= 500 && GetId() > 600 && athlete.IsRainSuitable)
        {
            return true;
        }
        else if (GetId() <= 600 && GetId() > 700 && athlete.IsSnowSuitable)
        {
            return true;
        }
        else if (GetId() == 800)
        {
            return true;
        }
        else if (GetId() > 800)
        {
            return false;
        }
        
        return null;
    }
}