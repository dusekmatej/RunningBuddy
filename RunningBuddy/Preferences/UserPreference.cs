using RunningBuddy.Models;
using RunningBuddy.Services;


namespace RunningBuddy.Preferences;

public abstract class UserPreference(ApiServiceForecast apiService) : IUserPreference
{
    private readonly ApiServiceForecast _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService), "Api Service is null!");
    private ForecastList? _data;
    public abstract bool IsSatisfied(Athlete athlete, string city, ForecastEntry? currentEntry);

    // Gets sunrise time for the specified city
    protected long GetSunrise(string city)
    {
        _data = _apiService.GetData(city);

        if (_data != null)
            return _data.City.Sunrise;

        throw new ArgumentNullException(nameof(_data), "Data is null!");
    }

    // Gets sunset time for the specified city
    protected long GetSunset(string city)
    {
        _data = _apiService.GetData(city);
        
        return _data.City.Sunset;
    }
}