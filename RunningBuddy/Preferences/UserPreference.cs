using System.Diagnostics;
using RunningBuddy.Services;
using RunningBuddy.Models;

namespace RunningBuddy.Preferences;

public abstract class UserPreference : IUserPreference
{
    private static ApiService? _apiService;
    private ApiList? _data;
    
    public abstract bool IsSatisfied(Athlete athlete, string city);

    protected UserPreference(ApiService apiService)
    {
        if (_apiService == null)
            Debug.WriteLine("ApiService is null");
        
        _apiService = apiService;
    }

    protected int GetId(string city)
    {
        _data = _apiService.GetData(city);
        var weather = _data.Weather[0];
        var returnValue = weather.Id;
        
        Logging.Log("Currently inside of GetId() " + returnValue + " " + city);
        
        return returnValue;
    }

    protected int GetTemp(string city)
    {
        _data = _apiService.GetData(city);
        Debug.WriteLine(_data.Main.Temp);
        var returnValue = _data.Main.Temp;
        
        Logging.Log("Currently inside of GetTemp() " + (int)returnValue + " " + city);
        
        return (int)returnValue;
    }
}