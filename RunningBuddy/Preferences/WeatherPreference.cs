using RunningBuddy.Services;
using RunningBuddy.Models;

namespace RunningBuddy.Preferences;

public class WeatherPreference : IUserPreference
{
    private static ApiService _apiService;
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
    public bool? IsSatisfied()
    {
        bool isThunderstormSuitable = false;
        bool isDrizzleSuitable = true;
        bool isRainSuitable = true;
        bool isSnowSuitable = false;
        
        
        if (GetId() > 200 && isThunderstormSuitable)
            return true;
        else if (GetId() > 300 && isDrizzleSuitable)
            return true;


        return null;
    }
}