using RunningBuddy.ModelsForecast;

namespace RunningBuddy.PreferencesForecast;

public interface IUserPreferenceF
{
    public bool IsSatisfied(Athlete athlete, string city, ForecastEntry? currentEntry);
}