using System.ComponentModel.Design.Serialization;

namespace RunningBuddy;

public static class AppState
{
    public static bool satisfiedTemperature { get; set; } = false;
    public static bool satisfiedWeather { get; set; } = false;
    public static bool satisfiedTime { get; set; } = false;
    
    public static string? FirstCity { get; set; }
    public static string? LastCity { get; set; }
}