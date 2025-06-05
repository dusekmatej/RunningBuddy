using RunningBuddy.Preferences;
using RunningBuddy.Models;


namespace RunningBuddy.Services;

public class Calculate
{
    // Constructor that calculates all the data
    public Calculate(Athlete athlete0, Athlete athlete1, List<ForecastEntry> forecastEntries0, List<ForecastEntry> forecastEntries1, ApiServiceForecast apiService)
    {
        var tempPref = new TemperaturePreference(apiService);
        var weatherPref = new WeatherPreference(apiService);
        var timePref = new TimePreference(apiService);

        for (int i = 0; i < forecastEntries0.Count && i < forecastEntries1.Count; i++)
        {
            athlete0.TemperatureSuitability = tempPref.IsSatisfied(athlete0, athlete0.Location, forecastEntries0[i]);
            athlete1.TemperatureSuitability = tempPref.IsSatisfied(athlete1, athlete1.Location, forecastEntries1[i]);

            if (athlete0.TemperatureSuitability && athlete1.TemperatureSuitability)
                AppState.satisfiedTemperature = true;
            
            athlete0.WeatherSuitability = weatherPref.IsSatisfied(athlete0, athlete0.Location, forecastEntries0[i]);
            athlete1.WeatherSuitability = weatherPref.IsSatisfied(athlete1, athlete1.Location, forecastEntries1[i]);
            
            if (athlete0.WeatherSuitability && athlete1.WeatherSuitability)
                AppState.satisfiedWeather = true;
            
            athlete0.TimeSuitability = timePref.IsSatisfied(athlete0, athlete0.Location, forecastEntries0[i]);
            athlete1.TimeSuitability = timePref.IsSatisfied(athlete1, athlete1.Location, forecastEntries1[i]);
            
            if (athlete0.TimeSuitability && athlete1.TimeSuitability)
                AppState.satisfiedTime = true;

            if (AppState.satisfiedTemperature && AppState.satisfiedTime && AppState.satisfiedWeather)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You can run together at {forecastEntries0[i].DtTxt}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("You cannot run together at " + forecastEntries0[i].DtTxt);
            }
            
            AppState.satisfiedTemperature = false;
            AppState.satisfiedWeather = false;
            AppState.satisfiedTime = false;

            athlete0.TimeSuitability = false;
            athlete1.TimeSuitability = false;
            athlete0.WeatherSuitability = false;
            athlete1.WeatherSuitability = false;
            athlete0.TemperatureSuitability = false;
            athlete1.TemperatureSuitability = false;
        }
        
        Console.ReadKey();
    }
}