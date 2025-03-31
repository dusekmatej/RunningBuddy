using RunningBuddy.Services;
using RunningBuddy.Models;
using RunningBuddy.Preferences;

namespace RunningBuddy;

public class Program
{
    // For this commit needed: AthletePreferences, working WeatherPref class just recognition required,
    
    public static void Main(String[] args)
    { 
        SaveManager sv = new SaveManager();
        
        ApiService api = new ApiService();

        ApiList? data = api.GetData("Hradec Kralove");

        if (data == null)
        {
            Console.WriteLine("Error download data");
        }
        
        Athlete athlete0 = new Athlete("jmeno");
        Athlete athlete1 = new Athlete("jmeno1");

        InputManager inputManager = new InputManager();
        
        inputManager.EnterAthlete(athlete0);
        Console.WriteLine($"Is rain suitable? {athlete0.IsRainSuitable}");
        athlete1.IsRainSuitable = true;

        var weatherPref = new WeatherPreference(api);
        
        bool? isWeatherPrefSuitable = weatherPref.IsSatisfied(athlete0);
        Console.WriteLine(isWeatherPrefSuitable);
 
        sv.DoesExist();
    }
}