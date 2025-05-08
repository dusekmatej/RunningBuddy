using RunningBuddy.Preferences;

namespace RunningBuddy.Services;

public class InputManager
{
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input!");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            return;
        }

        switch (userInput)
        {
            case 1:
                EnterAthlete(athlete0);
                break;
            case 2:
                EnterAthlete(athlete1);
                break;
            case 3:
                Calculate(athlete0, athlete1);
                break;
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

        if (athlete.athleteName == "LastAthlete")
            athlete.EnteredWeatherPref = true;
    }

    private void WeatherConditions(string[] conditionsArray, int inputCount, Athlete athlete)
    {
        Console.WriteLine(conditionsArray[inputCount]);
        string input = Console.ReadLine().ToLower();
        bool isComfortable;

        if (input == "yes" || input == "y")
        {
            isComfortable = true;
        }
        else if (input == "no" || input == "n")
        {
            isComfortable = false;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input!");
            Console.ResetColor();
            Console.ReadKey(true);
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
            default:
                return;
        }
    }

    private void Calculate(Athlete athlete0, Athlete athlete1)
    {
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
}