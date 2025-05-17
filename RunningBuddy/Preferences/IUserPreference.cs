namespace RunningBuddy.Preferences;

public interface IUserPreference
{
    public bool IsSatisfied(Athlete athlete, string city);
}