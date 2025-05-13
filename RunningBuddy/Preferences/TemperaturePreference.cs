using RunningBuddy.Services;

namespace RunningBuddy.Preferences;

public class TemperaturePreference(ApiService apiService) : UserPreference(apiService)
{
    private bool _preferenceSatisfied = false;
    public override bool IsSatisfied(Athlete athlete)
    {
        if (GetTemp() > athlete.MinTemp && GetTemp() < athlete.MaxTemp)
            _preferenceSatisfied = true;

        return _preferenceSatisfied;
    }
}