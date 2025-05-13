using System.ComponentModel;
using System.Diagnostics;
using RunningBuddy.Services;
using RunningBuddy.Models;
using RunningBuddy.Preferences;

namespace RunningBuddy;

public static class Program
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
        
        // Get api response & check if null
        ApiList? apiList = apiService.GetData("Hradec Kralove");
        
        if (apiList == null)
        {
            Console.WriteLine("Error: \"ApiList\" is null");
        }

        while (inputManager.isRunning)
        {
            inputManager.MainScreen(athlete0, athlete1);
        }
        inputManager.DebugLogs(athlete0, athlete1, consoleLogs);

        var weatherPref = new WeatherPreference(apiService);
        var tempPref = new TemperaturePreference(apiService);

        athlete0.TempPref = tempPref.IsSatisfied(athlete0);
        athlete1.TempPref = tempPref.IsSatisfied(athlete1);
        
        athlete0.WeatherSuitability = weatherPref.IsSatisfied(athlete0);
        athlete1.WeatherSuitability = weatherPref.IsSatisfied(athlete1);
    }
}