namespace RunningBuddy.Services;

public class EnterAthlete
{
    private int _questionNumber = 0;
    private readonly Render _render;
    
    // Constructor to initialize the Render instance
    public EnterAthlete(Render render)
    {
        _render = render;
    }
    
    // Method that calls all the other methods required to enter an athlete
    public void AthleteEnter(Athlete athlete)
    {
        EnterCity(athlete);
        EnterConditions(athlete);
        EnterLowTemp(athlete);
        EnterHighTemp(athlete);
        if (athlete.Id == "a1")
        {
            AppState.Athlete0Entered = true;
        }
        else if (athlete.Id == "a2")
        {
            AppState.Athlete1Entered = true;
        }
    }
    
    // Entering the conditions such as snow, rain etc.
    private void EnterConditions(Athlete athlete)
    {
        bool entered = false;
        
        string[] weatherCondQuestions = 
        {
            "Are you comfortable with running in stormy weather? (yes/no)",                              // 200–299
            "Are you comfortable with running in drizzle? (yes/no)",                                     // 300–399
            "Are you comfortable with running in rain? (yes/no)",                                        // 500–599
            "Are you comfortable with running in snow? (yes/no)",                                        // 600–699
            "Are you comfortable with running in mist, fog, or dusty conditions? (yes/no)",              // 700–799
            "Are you comfortable with running in clear sky/sunny weather? (yes/no)",                     // 800
            "Are you comfortable with running under cloudy skies? (yes/no)",                             // 801–804
            "Are you comfortable with running in extreme weather like hurricanes or tornadoes? (yes/no)" // 900–906
        };

        while (!entered)
        {
            string[] boolMenu = { "yes", "no" };

            int boolSelected = _render.BoolMenu(boolMenu, weatherCondQuestions, _questionNumber);
            bool isComfortable = boolSelected == 0;
            

            switch (_questionNumber)
            {
                case 0: athlete.IsStormSuitable = isComfortable; break;
                case 1: athlete.IsDrizzleSuitable = isComfortable; break;
                case 2: athlete.IsRainSuitable = isComfortable; break;
                case 3: athlete.IsSnowSuitable = isComfortable; break;
                case 4: athlete.IsAtmosphereSuitable = isComfortable; break;
                case 5: athlete.IsClearSuitable = isComfortable; break;
                case 6: athlete.IsCloudySuitable = isComfortable; break;
                case 7: athlete.IsExtremeSuitable = isComfortable; break;
            }
            
            if (_questionNumber < weatherCondQuestions.Length - 1)
                _questionNumber++;
            else if (_questionNumber == weatherCondQuestions.Length - 1)
            {
                _questionNumber = 0;
                entered = true;
            }
        }
    }
    
    // Entering the city and also checks if the city exists using API
    private void EnterCity(Athlete athlete)
    {
        Console.WriteLine("Entering athlete ");
        
        Console.WriteLine("Input city");
        string? city = Console.ReadLine();

        if (city != null && !new ApiServiceForecast().DoesCityExist(city))
        {
            ErrorMessage("City not found!");
            EnterCity(athlete);
            return;
        }

        athlete.Location = city;
        
        
        if (athlete.Id == "a1")
            AppState.FirstCity = athlete.Location;
        else if (athlete.Id == "a2")
            AppState.LastCity = athlete.Location;
    }
    
    // Entering the lowest temperature in which athlete is comfortable running
    private static void EnterLowTemp(Athlete athlete)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Input the lowest temperature you are comfortable with:");
        Console.ResetColor();
        
        var lowTemp = Console.ReadLine();
        
        if (!int.TryParse(lowTemp, out int lowTempInt))
        {
            ErrorMessage("Invalid input for lowest temperature!");
            Logging.Log("Invalid low temp input: " + lowTemp);
            EnterLowTemp(athlete);
        }

        athlete.MinTemp = lowTempInt;
    }
    
    // Entering the highest temperature in which athlete is comfortable running
    private static void EnterHighTemp(Athlete athlete)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Input the highest temperature you are comfortable with:");
        Console.ResetColor();
        
        var highTemp = Console.ReadLine();

        if (!int.TryParse(highTemp, out int highTempInt))
        {
            ErrorMessage("Invalid input for highest temperature!");
            Logging.Log("Invalid high temp input: " + highTemp);
            EnterHighTemp(athlete);
        }

        athlete.MaxTemp = highTempInt; 
    }
    
    // Method to display an error message
    private static void ErrorMessage(string errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMessage);
        Console.WriteLine("Press any key to continue...");
        Console.ResetColor();
        Console.ReadKey(true);
    }
}