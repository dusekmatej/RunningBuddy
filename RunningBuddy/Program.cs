using System.Diagnostics;
using RunningBuddy.Services;

namespace RunningBuddy;

public static class Program
{
    
    // Constructor
    // Creates instances of classes and starts while loop for the whole app
    public static void Main(String[] args)
    {
        Screens screen = new Screens();
        Logging.Entry();
        Logging.Log("Log writer initialized");
        
        // Create instances of classes
        SaveManager saveManager = new SaveManager("Users/");

        // Create athletes
        Athlete athlete0 = new Athlete("a1");
        Athlete athlete1 = new Athlete("a2");

        if (File.Exists("Users/user0.json"))
        {
            athlete0 = saveManager.Load("user0.json");
            AppState.LoadAthlete0AppState(athlete0);
            AppState.Athlete0Entered = true;
        }
        
        if (File.Exists("Users/user1.json"))
        {
            athlete1 = saveManager.Load("user1.json");
            AppState.LoadAthlete1AppState(athlete1);
            AppState.Athlete1Entered = true;
        }
        
        
        
        while (screen.IsRunning)
        {
            screen.MainScreen(athlete0, athlete1);
        }
        
        if (AppState.Athlete0Entered)
            saveManager.Save(athlete0, "Users/user0.json");

        if (AppState.Athlete1Entered)
            saveManager.Save(athlete1, "Users/user1.json");

        AthletesDebugger.DebugLogs(athlete0, athlete1);
    }
}