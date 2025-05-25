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
        SaveManager saveManager = new SaveManager("Users");

        // Create athletes
        Athlete athlete0 = new Athlete("a1");
        Athlete athlete1 = new Athlete("a2");

        if (saveManager.DoesDirectoryExist("Users"))
        {
            if (saveManager.DoesFileExist("Users/user0.json"))
                athlete0 = saveManager.Load("Users/user0.json");
            
            if (saveManager.DoesFileExist("Users/user1.json")) 
                athlete1 = saveManager.Load("Users/user1.json");
            
        }
        else
        {
            Logging.Log("Users directory does not exist, creating it");
        }
        
        
        
        while (screen.IsRunning)
        {
            screen.MainScreen(athlete0, athlete1);
        }
        
        saveManager.SaveAthletes(athlete0, athlete1);
        
        AthletesDebugger.DebugLogs(athlete0, athlete1);
    }
}