using System.Diagnostics;
using RunningBuddy.Services;

namespace RunningBuddy;

public static class Program
{
    public static void Main(String[] args)
    {
        Logging.Entry();
        Logging.Log("Log writer initialized");
        Debug.WriteLine("Log writer intialized");
        
        // Create instances of classes
        SaveManager saveManager = new SaveManager();
        InputManager inputManager = new InputManager();

        // Create athletes
        Athlete athlete0 = new Athlete("a1");
        Athlete athlete1 = new Athlete("a2");
        
        saveManager.LoadAthletes(athlete0, athlete1);
        
        while (inputManager.IsRunning)
        {
            inputManager.MainScreen(athlete0, athlete1);
        }
        
        saveManager.SaveAthletes(athlete0, athlete1);
        
        AthletesDebugger.DebugLogs(athlete0, athlete1);
    }
}