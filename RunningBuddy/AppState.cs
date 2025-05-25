using System.ComponentModel.Design.Serialization;

namespace RunningBuddy;

public static class AppState
{
    public static bool satisfiedTemperature { get; set; } = false;
    public static bool satisfiedWeather { get; set; } = false;
    public static bool satisfiedTime { get; set; } = false;
    public static bool satisfiedBothAthletes { get; set; } = false;
    
    public static string? FirstCity { get; set; }
    public static string? LastCity { get; set; }

    public static bool Athlete0Entered { get; set; } = false;
    public static bool Athlete1Entered { get; set; } = false;
    
    public static bool AthletesEntered { get; set; } = false;

    
    // Loading some of athlete's preference to the AppState
    public static void LoadAthlete0AppState(Athlete athlete0)
    {
        FirstCity = athlete0.Location;
    }

    // Loading some of athlete's preference to the AppState
    public static void LoadAthlete1AppState(Athlete athlete1)
    {
        LastCity = athlete1.Location;
    }
}