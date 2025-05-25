namespace RunningBuddy.Services;

public class Screens
{
    private static readonly Render Render = new Render();
    private readonly EnterAthlete _enterAthlete = new EnterAthlete(Render);
    private readonly SaveManager _saveManager = new SaveManager("Users");

    public bool IsRunning = true;
    
    // It's set up this way for the custom ui to work

    public Screens()
    {
        Logging.Log("Class screens initialized.");
    }
    
    
    // Main screen of the application
    public void MainScreen(Athlete athlete0, Athlete athlete1)
    {
        var apiService = new ApiServiceForecast();
        Calculate calc;
        
        string[] mainMenu = { "Enter athletes", "Calculate", "Exit" };
        int mainMenuChoice = Render.ShowMenu(mainMenu, "Running Buddy");
        
        switch (mainMenuChoice)
        {
            case 0:
                Console.Clear();
                AthletesSelectionMenu(athlete0, athlete1);
                break;
            case 1:
                Console.Clear();
                var forecastEntries0 = apiService.GetData(AppState.FirstCity).List;
                var forecastEntries1 = apiService.GetData(AppState.LastCity).List;
                if (AppState.Athlete0Entered && AppState.Athlete1Entered)
                {
                    calc = new Calculate(athlete0, athlete1, forecastEntries0, forecastEntries1, apiService);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("First you need to enter both athletes");
                    Console.ResetColor();
                }
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("Exiting...");
                IsRunning = false;
                return;
        }
    }
    
    
    // Menu for selecting athletes
    private void AthletesSelectionMenu(Athlete athlete0, Athlete athlete1)
    {
        while (true)
        {
            string[] athleteMenu = { "Athlete one", "Athlete two", "Delete athlete one", "Delete athlete two", "Delete both Athletes", "Back to Main Menu" };

            int athleteSelection = Render.ShowMenu(athleteMenu, "Select Athlete to enter!");

            switch (athleteSelection)
            {
                case 0:
                    Console.Clear();
                    _enterAthlete.AthleteEnter(athlete0);
                    AppState.Athlete0Entered = true;
                    break;
                case 1:
                    Console.Clear();
                    _enterAthlete.AthleteEnter(athlete1);
                    AppState.Athlete1Entered = true;
                    break;
                case 2:
                    _saveManager.DeleteAthlete("Users/user0.json");
                    Console.WriteLine("Athlete one deleted!");
                    break;
                case 3:
                    _saveManager.DeleteAthlete("Users/user1.json");
                    Console.WriteLine("Athlete two deleted!");
                    break;
                case 4:
                    _saveManager.DeleteAthletes();
                    Console.WriteLine("Both athletes deleted!");
                    break;
                case 5:
                    return;
            }
        }
    }
}