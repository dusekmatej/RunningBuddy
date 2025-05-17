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

    public static bool AthletesEntered { get; set; } = false;

    public static void LoadAthletesToAppState(Athlete athlete0, Athlete athlete1)
    {
        FirstCity = athlete0.Location;
        LastCity = athlete1.Location;
    }
}