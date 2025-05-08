using System.ComponentModel;
using System.Diagnostics;
using RunningBuddy.Services;
using RunningBuddy.Models;
using RunningBuddy.Preferences;

namespace RunningBuddy;

public class Program
{
    
    public static void Main(String[] args)
    {
        bool consoleLogs = true;
        
        // Create instances of classes
        ApiService? apiService = new ApiService();
        SaveManager saveManager = new SaveManager();
        InputManager inputManager = new InputManager();

        // Create athletes
        Athlete athlete0 = new Athlete();
        Athlete athlete1 = new Athlete();

        athlete1.athleteName = "LastAthlete";
        
        // Get api response & check if null
        ApiList? apiList = apiService.GetData("Hradec Kralove");
        apiList = apiService.GetData("Hradec Kralove");
        
        if (apiList == null)
        {
            Console.WriteLine("Error:");
        }

        while (!athlete1.EnteredWeatherPref)
        {
            inputManager.MainScreen(athlete0, athlete1);
        }
        //inputManager.MainScreen();

        var weatherPref = new WeatherPreference(apiService);

        athlete0.IsWeatherSuitable = weatherPref.IsSatisfied(athlete0);
        athlete1.IsWeatherSuitable = weatherPref.IsSatisfied(athlete1);
 
        if (consoleLogs)
        {
            Debug.WriteLine($"Athlete zero suitability: {athlete0.IsWeatherSuitable}");;
            Debug.WriteLine($"Athlete one suitability: {athlete1.IsWeatherSuitable}");;
            
            Debug.WriteLine($"Athlete0 is storm suitable {athlete0.IsStormSuitable}");
            Debug.WriteLine($"Athlete0 is rain suitable {athlete0.IsRainSuitable}");
            Debug.WriteLine($"Athlete0 is drizzle suitable {athlete0.IsDrizzleSuitable}");
            Debug.WriteLine($"Athlete0 is snow suitable {athlete0.IsSnowSuitable}");

            Debug.WriteLine($"Athlete1 is storm suitable {athlete1.IsStormSuitable}");
            Debug.WriteLine($"Athlete1 is rain suitable {athlete1.IsRainSuitable}");
            Debug.WriteLine($"Athlete1 is drizzle suitable {athlete1.IsDrizzleSuitable}");
            Debug.WriteLine($"Athlete1 is snow suitable {athlete1.IsSnowSuitable}");
        }
    }
}