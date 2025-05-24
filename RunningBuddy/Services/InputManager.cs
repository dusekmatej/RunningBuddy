using RunningBuddy.ModelsForecast;
using RunningBuddy.Preferences;
using RunningBuddy.PreferencesForecast;
using TimePreference = RunningBuddy.PreferencesForecast.TimePreference;

namespace RunningBuddy.Services;

public class InputManager
{
    private bool _validInput = false;
    public bool IsRunning = true;
    
    private int _questionNumber = 0;
    
    private void ErrorMessage(string errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMessage);
        Console.WriteLine("Press any key to continue...");
        Console.ResetColor();
        Console.ReadKey(true);
    }

    public void MainScreen(Athlete athlete0, Athlete athlete1)
    {
        string[] mainMenu = { "Enter athletes", "Calculate", "Exit" };
        int mainMenuChoice = ShowMenu(mainMenu, "Running Buddy");

        switch (mainMenuChoice)
        {
            case 0:
                Console.Clear();
                AthletesSelectionMenu(athlete0, athlete1);
                break;
            case 1:
                Calculate(athlete0, athlete1);
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("Exiting...");
                IsRunning = false;
                return;
        }
    }

    private void AthletesSelectionMenu(Athlete athlete0, Athlete athlete1)
    {
        while (true)
        {
            string[] athleteMenu = { "Athlete one", "Athlete two", "Back to Main Menu" };

            int athleteSelection = ShowMenu(athleteMenu, "Select Athlete to enter!");

            switch (athleteSelection)
            {
                case 0:
                    Console.Clear();
                    EnterAthlete(athlete0);
                    AppState.Athlete0Entered = true;
                    break;
                case 1:
                    Console.Clear();
                    EnterAthlete(athlete1);
                    AppState.Athlete1Entered = true;
                    break;
                case 2:
                    return;
            }


        }
    }

    private void EnterAthlete(Athlete athlete)
    {
        EnterCity(athlete);
        
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

            int boolSelected = BoolMenu(boolMenu, weatherCondQuestions, _questionNumber);
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

        EnterLowTemp(athlete);
        EnterHighTemp(athlete);
    }
    
    private int ShowMenu(string[] options, string title)
    {
        int selectedItem = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"----- {title} -----");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedItem)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("-> ");
                }
                else
                    Console.Write("  ");
                
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
            
            

            ConsoleKey inputKey = Console.ReadKey(true).Key;

            switch (inputKey)
            {
                case ConsoleKey.Enter:
                    return selectedItem;
                
                case ConsoleKey.UpArrow:
                    selectedItem--;
                    
                    if (selectedItem < 0)
                        selectedItem = options.Length - 1;
                    break;
                
                case ConsoleKey.DownArrow:
                    selectedItem++;
                    if (selectedItem == options.Length)
                        selectedItem = 0;
                    break;
            }
            
        }
    }
    
    private int BoolMenu(string[] boolMenu, string[] questionsArray, int questionIndex)
    {
        int selectedBool = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(questionsArray[questionIndex]);
            
            for (int i = 0; i < boolMenu.Length; i++)
            {
                if (i == selectedBool)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("-> ");
                }
                else
                {
                    Console.Write("  ");
                }
                
                Console.WriteLine(boolMenu[i]);
                Console.ResetColor();
            }
            
            ConsoleKey inputKey = Console.ReadKey(true).Key;

            switch (inputKey)
            {
                case ConsoleKey.Enter:
                    return selectedBool;
                
                case ConsoleKey.UpArrow:
                    selectedBool--;

                    if (selectedBool < 0)
                        selectedBool = boolMenu.Length - 1;

                    break;
                
                case ConsoleKey.DownArrow:
                    selectedBool++;

                    if (selectedBool > boolMenu.Length - 1)
                        selectedBool = 0;

                    break;
            }
        }
    }
    
    private void EnterCity(Athlete athlete)
    {
        Console.WriteLine("Entering athlete ");
        
        Console.WriteLine("Input city");
        string? city = Console.ReadLine();

        if (city != null && !new ApiService().DoesCityExist(city))
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
    
    private bool EnterLowTemp(Athlete athlete)
    {
        Console.WriteLine("Input the lowest temperature you are comfortable with:");
        var lowTemp = Console.ReadLine();
        
        if (!int.TryParse(lowTemp, out int lowTempInt))
        {
            ErrorMessage("Invalid input for lowest temperature!");
            Logging.Log("Invalid low temp input: " + lowTemp);
            return false;
        }

        athlete.MinTemp = lowTempInt;
        return true;
    }

    private bool EnterHighTemp(Athlete athlete)
    {
        Console.WriteLine("Input the highest temperature you are comfortable with:");
        var highTemp = Console.ReadLine();

        if (!int.TryParse(highTemp, out int highTempInt))
        {
            ErrorMessage("Invalid input for highest temperature!");
            Logging.Log("Invalid high temp input: " + highTemp);
            return false;
        }

        athlete.MaxTemp = highTempInt;
        return true;
    }

    private void Calculate(Athlete athlete0, Athlete athlete1)
    {
        var apiService = new ApiServiceForecast();
        var forecastEntries0 = apiService.GetData(AppState.FirstCity).List;
        var forecastEntries1 = apiService.GetData(AppState.LastCity).List;
        
        EvaluateEntries(athlete0, athlete1, forecastEntries0, forecastEntries1, apiService);
    }
    
    private void EvaluateEntries(Athlete athlete0, Athlete athlete1, List<ForecastEntry> forecastEntries0, List<ForecastEntry> forecastEntries1, ApiServiceForecast apiService)
    {
        var tempPref = new TempPreferenceF(apiService);
        var weatherPref = new WeatherPreferenceF(apiService);
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
                Console.WriteLine($"You can run together at {forecastEntries0[i].DtTxt}");
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
