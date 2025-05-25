namespace RunningBuddy.Services;

public static class AthletesDebugger
{
    
    // Writing debug logs into logs.txt file for easier debugging what works and what doesn't
    public static void DebugLogs(Athlete athlete0, Athlete athlete1)
    {
        Logging.Log("-----------------------------------------------------");
        Logging.Log("---------- Athlete one ----------");
        Logging.Log("Athlete ID: " + athlete0.Id);
        Logging.Log("------- Temperature -------");
        Logging.Log($"Minimal temperature: {athlete0.MinTemp}");
        Logging.Log($"Maximal temperature: {athlete0.MaxTemp}");
        Logging.Log($"Athlete one temperature preference is {athlete0.TemperatureSuitability}");
        Logging.Log("------- Weather -------");
        Logging.Log($"Weather suitability for athlete one with API data: {athlete0.WeatherSuitability}");
        Logging.Log("------- Separate athlete weather attributes -------");
        Logging.Log($"Athlete one suitability: {athlete0.WeatherSuitability}");
        Logging.Log($"Athlete one is storm suitable: {athlete0.IsStormSuitable}");
        Logging.Log($"Athlete one is drizzle suitable: {athlete0.IsDrizzleSuitable}");
        Logging.Log($"Athlete one is rain suitable: {athlete0.IsRainSuitable}");
        Logging.Log($"Athlete one is snow suitable: {athlete0.IsSnowSuitable}");
        Logging.Log($"Athlete one is atmosphere suitable: {athlete0.IsAtmosphereSuitable}");
        Logging.Log($"Athlete one is clear sky suitable: {athlete0.IsClearSuitable}");
        Logging.Log($"Athlete one is cloudy suitable: {athlete0.IsCloudySuitable}");
        Logging.Log($"Athlete one is extreme weather suitable: {athlete0.IsExtremeSuitable}");
        Logging.Log("");
        Logging.Log("---------- Athlete two ----------");
        Logging.Log("Athlete ID: " + athlete1.Id);
        Logging.Log("------- Temperature -------");
        Logging.Log($"Minimal temperature: {athlete1.MinTemp}");
        Logging.Log($"Maximal temperature: {athlete1.MaxTemp}");
        Logging.Log($"Athlete two temperature preference is {athlete1.TemperatureSuitability}");
        Logging.Log("------- Weather -------");
        Logging.Log($"Weather suitability for athlete two with API data: {athlete1.WeatherSuitability}");
        Logging.Log("------- Separate athlete weather attributes -------");
        Logging.Log($"Athlete two suitability: {athlete1.WeatherSuitability}");
        Logging.Log($"Athlete two is storm suitable: {athlete1.IsStormSuitable}");
        Logging.Log($"Athlete two is drizzle suitable: {athlete1.IsDrizzleSuitable}");
        Logging.Log($"Athlete two is rain suitable: {athlete1.IsRainSuitable}");
        Logging.Log($"Athlete two is snow suitable: {athlete1.IsSnowSuitable}");
        Logging.Log($"Athlete two is atmosphere suitable: {athlete1.IsAtmosphereSuitable}");
        Logging.Log($"Athlete two is clear sky suitable: {athlete1.IsClearSuitable}");
        Logging.Log($"Athlete two is cloudy suitable: {athlete1.IsCloudySuitable}");
        Logging.Log($"Athlete two is extreme weather suitable: {athlete1.IsExtremeSuitable}");
        Logging.Log("---------- All AppState variables ----------");
        Logging.Log($"Are both athletes satisfied with the temperature conditions: {AppState.satisfiedTemperature}");
        Logging.Log($"Are both athletes satisfied with the weather conditions: {AppState.satisfiedWeather}");
        Logging.Log($"Are both athletes satisfied with the time conditions: {AppState.satisfiedTime}");
        Logging.Log($"Are both athletes satisfied overall: {AppState.satisfiedBothAthletes}");
        Logging.Log($"First city entered by athlete 0: {AppState.FirstCity}");
        Logging.Log($"Last city entered by athlete 1: {AppState.LastCity}");
        Logging.Log($"Has athlete 0 been entered: {AppState.Athlete0Entered}");
        Logging.Log($"Has athlete 1 been entered: {AppState.Athlete1Entered}");
        Logging.Log($"Have both athletes been entered: {AppState.AthletesEntered}");
        Logging.Log("-----------------------------------------------------");
    }
}