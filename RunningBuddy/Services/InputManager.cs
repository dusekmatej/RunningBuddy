using System.Diagnostics;
using RunningBuddy.Preferences;

namespace RunningBuddy.Services;

public class InputManager
{
    private bool _validInput = false;
    public bool IsRunning = true;
    
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
        bool athletesEntered = true;

        Console.WriteLine("----- Welcome to Running Buddy -----");
        Console.WriteLine("1) Enter athletes");
        if (athletesEntered)
            Console.WriteLine("2) Calculate times!");
        Console.WriteLine("3) Exit");

        if (!int.TryParse(Console.ReadLine(), out int userInput))
        {
            ErrorMessage("Invalid input!");
            return;
        }

        switch (userInput)
        {
            case 1: 
                Console.WriteLine("----- Entering athlete one -----");
                EnterAthlete(athlete0); 
                Console.WriteLine("----- Entering athlete two -----");
                EnterAthlete(athlete1); 
                break;
            case 2: Calculate(athlete0, athlete1); break;
            case 3: IsRunning = false; break;
        }
    }

    private void EnterAthlete(Athlete athlete)
    {
        EnterCity(athlete);

        string[] weatherCondQuestions = new string[]
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


        for (int i = weatherCondQuestions.Length - 1; i >= 0; i--)
        {
            Logging.Log("Inside in EnterAthlete() .for loop run trough " + i);
            _validInput = false;
            while (!_validInput)
            {
                _validInput = WeatherConditions(weatherCondQuestions, i, athlete);
            }
        }

        _validInput = false;
        while (!_validInput)
        {
            _validInput = false;
            _validInput = EnterLowTemp(athlete);
        }

        _validInput = false;
        while (!_validInput)
        {
            _validInput = false;
            _validInput = EnterHighTemp(athlete);
        }
    }

    private bool WeatherConditions(string[] conditionsArray, int inputCount, Athlete athlete)
    {
        Console.WriteLine(conditionsArray[inputCount]);
        string input = Console.ReadLine().ToLower();
        bool isComfortable = false;

        if (input == "yes" || input == "y")
            isComfortable = true;
        else if (input == "no" || input == "n")
            isComfortable = false;
        else
        {
            Logging.Log("Invalid input for weather condition! " + input);
            return false;
        }

        switch (inputCount)
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

        return true;
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
        Console.WriteLine("Are both athletes satisfied with the weather?");
        
        Console.WriteLine("Athlete0 city is: " + athlete0.Location);
        Console.WriteLine("Athlete1 city is: " + athlete1.Location);
    }

    public void DebugLogs(Athlete athlete0, Athlete athlete1)
    {
        Logging.Log("---------- Athlete one ----------");
        Logging.Log("Weather suitability for athlete one with API data: " + athlete0.WeatherSuitability);
        Logging.Log($"Athlete one temperature preference is {athlete0.TemperatureSuitability}");
        Logging.Log(" ");
        Logging.Log($"Athlete one suitability: {athlete0.WeatherSuitability}");
        Logging.Log($"Athlete one is storm suitable: {athlete0.IsStormSuitable}");
        Logging.Log($"Athlete one is drizzle suitable: {athlete0.IsDrizzleSuitable}");
        Logging.Log($"Athlete one is rain suitable: {athlete0.IsRainSuitable}");
        Logging.Log($"Athlete one is snow suitable: {athlete0.IsSnowSuitable}");
        Logging.Log($"Athlete one is atmosphere suitable: {athlete0.IsAtmosphereSuitable}");
        Logging.Log($"Athlete one is clear sky suitable: {athlete0.IsClearSuitable}");
        Logging.Log($"Athlete one is cloudy suitable: {athlete0.IsCloudySuitable}");
        Logging.Log($"Athlete one is extreme weather suitable: {athlete0.IsExtremeSuitable}");

        Logging.Log("---------- Athlete two ----------");
        Logging.Log("Weather suitability for athlete two with API data: " + athlete1.WeatherSuitability);
        Logging.Log($"Athlete two temperature preference is {athlete1.TemperatureSuitability}");
        Logging.Log(" ");
        Logging.Log($"Athlete two suitability: {athlete1.WeatherSuitability}");
        Logging.Log($"Athlete two is storm suitable: {athlete1.IsStormSuitable}");
        Logging.Log($"Athlete two is drizzle suitable: {athlete1.IsDrizzleSuitable}");
        Logging.Log($"Athlete two is rain suitable: {athlete1.IsRainSuitable}");
        Logging.Log($"Athlete two is snow suitable: {athlete1.IsSnowSuitable}");
        Logging.Log($"Athlete two is atmosphere suitable: {athlete1.IsAtmosphereSuitable}");
        Logging.Log($"Athlete two is clear sky suitable: {athlete1.IsClearSuitable}");
        Logging.Log($"Athlete two is cloudy suitable: {athlete1.IsCloudySuitable}");
        Logging.Log($"Athlete two is extreme weather suitable: {athlete1.IsExtremeSuitable}");
    }
}
