using System.Diagnostics;
using RunningBuddy.Preferences;

namespace RunningBuddy.Services;

public class InputManager
{
    public bool isRunning = true;
    
    private void ErrorMessage(string errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMessage);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
    
    public void MainScreen(Athlete athlete0, Athlete athlete1)
    {
        bool athletesEntered = true;

        Console.WriteLine("----- Welcome to Running Buddy -----");
        Console.WriteLine("1) Enter athlete one");
        Console.WriteLine("2) Enter athlete two");
        if (athletesEntered)
            Console.WriteLine("3) Calculate times!");
        Console.WriteLine("4) Exit");

        if (!int.TryParse(Console.ReadLine(), out int userInput))
        {
            ErrorMessage("Invalid input!");
            return;
        }

        switch (userInput)
        {
            case 1: EnterAthlete(athlete0); break;
            case 2: EnterAthlete(athlete1); break;
            case 3: Calculate(athlete0, athlete1); break;
            case 4: isRunning = false; break;
        }
    }

    private void EnterAthlete(Athlete athlete)
    {
        string[] weatherCondQuestions = new string[]
        {
            "Are you comfortable with running in stormy weather? (yes/no)",
            "Are you comfortable with running in drizzle? (yes/no)",
            "Are you comfortable with running in rain? (yes/no)",
            "Are you comfortable with running in snow? (yes/no)"
        };

        for (int i = weatherCondQuestions.Length - 1; i >= 0; i--)
        {
            Console.WriteLine(i);
            WeatherConditions(weatherCondQuestions, i, athlete);
        }
        
        EnterTemp(athlete);
    }

    private void WeatherConditions(string[] conditionsArray, int inputCount, Athlete athlete)
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
            ErrorMessage("Invalid input!");
            return;
        }

        switch (inputCount)
        {
            case 0: 
                athlete.IsStormSuitable = isComfortable;
                break;
            case 1: 
                athlete.IsDrizzleSuitable = isComfortable;
                break;
            case 2: 
                athlete.IsRainSuitable = isComfortable;
                break;
            case 3: 
                athlete.IsSnowSuitable = isComfortable; 
                break;
        }
    }

    private void EnterTemp(Athlete athlete)
    {
        Console.WriteLine("Input the lowest temperature you are comfortable with:");
        var lowTemp = Console.ReadLine();
        Console.WriteLine("Input the highest temperature you are comfortable with:");
        var highTemp = Console.ReadLine();

        if (!int.TryParse(lowTemp, out int lowTempInt))
        {
            ErrorMessage("Invalid input for lowest temperature!");
            return;
        }
        
        if (!int.TryParse(highTemp, out int highTempInt))
        {
            ErrorMessage("Invalid input for highest temperature!");
            return;
        }

        athlete.MinTemp = lowTempInt;
        athlete.MaxTemp = highTempInt;
    }

    private void Calculate(Athlete athlete0, Athlete athlete1)
    {
        Console.WriteLine($"");
        Console.WriteLine($"");
        
        Console.WriteLine($"Athlete0 is storm suitable {athlete0.IsStormSuitable}");
        Console.WriteLine($"Athlete0 is rain suitable {athlete0.IsRainSuitable}");
        Console.WriteLine($"Athlete0 is drizzle suitable {athlete0.IsDrizzleSuitable}");
        Console.WriteLine($"Athlete0 is snow suitable {athlete0.IsSnowSuitable}");

        Console.WriteLine($"Athlete1 is storm suitable {athlete1.IsStormSuitable}");
        Console.WriteLine($"Athlete1 is rain suitable {athlete1.IsRainSuitable}");
        Console.WriteLine($"Athlete1 is drizzle suitable {athlete1.IsDrizzleSuitable}");
        Console.WriteLine($"Athlete1 is snow suitable {athlete1.IsSnowSuitable}");
    }

    public void DebugLogs(Athlete athlete0, Athlete athlete1, bool consoleLogs)
    {
        if (consoleLogs)
        {
            Debug.WriteLine($"Athlete zero temperature preference is {athlete0.TempPref}");
            Debug.WriteLine($"Athlete two temperature preference is {athlete1.TempPref}");
            
            Debug.WriteLine($"Athlete zero suitability: {athlete0.WeatherSuitability}");;
            Debug.WriteLine($"Athlete one suitability: {athlete1.WeatherSuitability}");;
            
            Debug.WriteLine($"Athlete0 is storm suitable {athlete0.IsStormSuitable}");
            Debug.WriteLine($"Athlete0 is rain suitable {athlete0.IsRainSuitable}");
            Debug.WriteLine($"Athlete0 is drizzle suitable {athlete0.IsDrizzleSuitable}");
            Debug.WriteLine($"Athlete0 is snow suitable {athlete0.IsSnowSuitable}");

            Debug.WriteLine($"Athlete1 is storm suitable {athlete1.IsStormSuitable}");
            Debug.WriteLine($"Athlete1 is rain suitable {athlete1.IsRainSuitable}");
            Debug.WriteLine($"Athlete1 is drizzle suitable {athlete1.IsDrizzleSuitable}");
            Debug.WriteLine($"Athlete1 is snow suitable {athlete1.IsSnowSuitable}");
        }
    }
}
