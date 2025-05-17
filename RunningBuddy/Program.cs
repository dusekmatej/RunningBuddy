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
        Logging.Entry();
        Logging.Log("Log writer initialized");
        
        bool consoleLogs = true;
        
        // Create instances of classes
        ApiService? apiService = new ApiService();
        SaveManager saveManager = new SaveManager();
        InputManager inputManager = new InputManager();

        // Create athletes
        Athlete athlete0 = new Athlete("a1");
        Athlete athlete1 = new Athlete("a2");
        
        Logging.Log("Instances created");
        
        while (inputManager.IsRunning)
        {
            inputManager.MainScreen(athlete0, athlete1);
        }

        var weatherPref = new WeatherPreference(apiService);
        var tempPref = new TemperaturePreference(apiService);


        if (athlete0.Location != null)
        {
            athlete0.WeatherSuitability = weatherPref.IsSatisfied(athlete0, athlete0.Location);
            athlete0.TemperatureSuitability = tempPref.IsSatisfied(athlete0, athlete0.Location);
        }

        if (athlete1.Location != null)
        {
            athlete1.WeatherSuitability = weatherPref.IsSatisfied(athlete1, athlete1.Location);
            athlete1.TemperatureSuitability = tempPref.IsSatisfied(athlete1, athlete1.Location);        
        }

        
        
        
        inputManager.DebugLogs(athlete0, athlete1);
    }
}