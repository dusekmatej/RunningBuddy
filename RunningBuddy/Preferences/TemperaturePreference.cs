using RunningBuddy.Services;

namespace RunningBuddy.Preferences;

public class TemperaturePreference(ApiService apiService) : UserPreference(apiService)
{
    private bool _preferenceSatisfied = false;
    public override bool IsSatisfied(Athlete athlete, string city)
    {
        if (GetTemp(city) > athlete.MinTemp && GetTemp(city) < athlete.MaxTemp)
            _preferenceSatisfied = true;

        return _preferenceSatisfied;
    }
}