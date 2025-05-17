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
        Debug.WriteLine("Log writer intialized");
        
        bool consoleLogs = true;
        
        // Create instances of classes
        SaveManager saveManager = new SaveManager();
        InputManager inputManager = new InputManager();

        // Create athletes
        // Athlete athlete0 = new Athlete("a1");
        // Athlete athlete1 = new Athlete("a2");

        Athlete athlete0 = new Athlete("a1");
        Athlete athlete1 = new Athlete("a2");
        if (saveManager.DoesExist("user0.json") && saveManager.DoesExist("user1.json"))
        {
            athlete0 = saveManager.Load("user0.json");
            athlete1 = saveManager.Load("user1.json");
            AppState.LoadAthletesToAppState(athlete0, athlete1);

            AppState.AthletesEntered = true;
        }
        
        while (inputManager.IsRunning)
        {
            inputManager.MainScreen(athlete0, athlete1);
        }
        
        saveManager.Save(athlete0, "user0.json");
        saveManager.Save(athlete1, "user1.json");
        
        inputManager.DebugLogs(athlete0, athlete1);
    }
}