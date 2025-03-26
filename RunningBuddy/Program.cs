using RunningBuddy.Services;
using RunningBuddy.Models;
using RunningBuddy.Preferences;

namespace RunningBuddy;

public class Program
{
    public static void Main(String[] args)
    { 
        SaveManager sv = new SaveManager();
        
        ApiService api = new ApiService();

        ApiList? data = api.GetData("Hradec Kralove");

        if (data == null)
        {
            Console.WriteLine("Error download data");
        }
        
        Athlete athlete0 = new Athlete();

        var weatherPref = new WeatherPreference(api);
        
        bool? isWeatherPrefSuitable = weatherPref.IsSatisfied();
        Console.WriteLine(isWeatherPrefSuitable);
 
        sv.DoesExist();
    }
}