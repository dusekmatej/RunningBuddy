namespace RunningBuddy.Preferences;

public class TimePreference : IUserPreference
{
    public bool IsSatisfied(Athlete athlete, string city)
    {
        return true;
    }
}