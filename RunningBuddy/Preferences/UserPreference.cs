using System.Diagnostics;
using RunningBuddy.Services;
using RunningBuddy.Models;

namespace RunningBuddy.Preferences;

public abstract class UserPreference : IUserPreference
{
    private static ApiService? _apiService;
    private ApiList? _data;
    public abstract bool IsSatisfied(Athlete athlete);

    protected UserPreference(ApiService apiService)
    {
        if (_apiService == null)
            Debug.WriteLine("ApiService is null");
        
        _apiService = apiService;
    }

    protected int GetId()
    {
        _data = _apiService.GetData("Hradec Kralove");
        var weather = _data.Weather[0];
        var returnValue = weather.Id;
        
        return returnValue;
    }

    protected int GetTemp()
    {
        _data = _apiService.GetData("Hradec Kralove");
        var returnValue = _data.Main.Temp;

        return (int)returnValue;
    }
}