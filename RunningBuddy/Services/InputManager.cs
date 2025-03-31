namespace RunningBuddy.Services;

public class InputManager
{
    public void MainScreen()
    {
        bool athletesEntered = true; // Just for testing purposes
        Console.WriteLine("----- Welcome to Running Buddy -----");
        Console.WriteLine("1) Enter athlete one");
        Console.WriteLine("2) Enter athlete two");
        if (athletesEntered)
            Console.WriteLine("3) Calculate times!");
        Console.WriteLine("4) Exit");
    }

    public void EnterAthlete(Athlete athlete)
    {
        // Try to make better souloution for this long code, not readable
        
        // Possibilities harder to implement
        // possibility of making a list of responses then do for/foreach loop
        // Possibility of making a list of questions and then cycling through them
        
        Console.Clear();
        Console.WriteLine($"Entering information for athlete {athlete.athleteName}");
        
        Console.WriteLine("Are you comfortable with running in stormy weather? (yes/no)");
        string? stormyWeather = Console.ReadLine();

        if (stormyWeather.ToLower() == "yes" || stormyWeather.ToLower() == "y")
        {
            athlete.IsStormSuitable = true;

        }
        else if (stormyWeather.ToLower() == "no" || stormyWeather.ToLower() == "n")
        {
            athlete.IsStormSuitable = false;
        }
        else
        {
            Console.WriteLine("Wrong input, please try again.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Are you comfortable with running in drizzle? (yes/no)");
        string? drizzleWeather = Console.ReadLine();
        
        if (drizzleWeather.ToLower() == "yes" || drizzleWeather.ToLower() == "y")
        {
            athlete.IsStormSuitable = true;

        }
        else if (drizzleWeather.ToLower() == "no" || drizzleWeather.ToLower() == "n")
        {
            athlete.IsStormSuitable = false;
        }
        else
        {
            Console.WriteLine("Wrong input, please try again.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Are you comfortable with running in rain? (yes/no)");
        string? rainWeather = Console.ReadLine();
        
        if (rainWeather.ToLower() == "yes" || rainWeather.ToLower() == "y")
        {
            athlete.IsRainSuitable = true;
        }
        else if (rainWeather.ToLower() == "no" || rainWeather.ToLower() == "n")
        {
            athlete.IsRainSuitable = false;
        }
        else
        {
            Console.WriteLine("Wrong input, please try again.");
            Console.ReadKey();
            return;
        }
        
        Console.WriteLine("Are you comfortable with running in snow? (yes/no)");
        string? snowWeather = Console.ReadLine();
        
        if (snowWeather.ToLower() == "yes" || snowWeather.ToLower() == "y")
        {
            athlete.IsStormSuitable = true;
        }
        else if (snowWeather.ToLower() == "no" || snowWeather.ToLower() == "n")
        {
            athlete.IsStormSuitable = false;
        }
        else
        {
            Console.WriteLine("Wrong input, please try again.");
            Console.ReadKey();
            return;
        }
    }

    public void WriteAthletes(int athleteNumber)
    {
        Console.WriteLine();
    }
}