namespace RunningBuddy.Services;

public class CheckPreferences
{
    public bool ArePreferencesSatisfied(Athlete athlete0, Athlete athlete1)
    {
        if (athlete0.TemperatureSuitability && athlete1.TemperatureSuitability)
            AppState.satisfiedTemperature = true;
        
        if (athlete0.TimeSuitability && athlete1.TimeSuitability)
            AppState.satisfiedTime = true;
        
        if (athlete0.WeatherSuitability && athlete1.WeatherSuitability)
            AppState.satisfiedWeather = true;

        if (AppState.satisfiedTemperature && AppState.satisfiedTime && AppState.satisfiedWeather)
            return true;

        return false;
    }
}