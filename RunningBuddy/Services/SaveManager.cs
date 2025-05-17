using System.Text.Json;
using System.IO;
using RunningBuddy.Services;

namespace RunningBuddy;

public class SaveManager
{
    public bool DoesExist(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Logging.Log("File does not exist");
            return false;
        }
        
        Logging.Log("File exists");
        return true;
    }
    
    public void Save(Athlete athlete, string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(athlete, options);
        File.WriteAllText(filePath, json);
    }

    public Athlete Load(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("File not found");
        
        string json = File.ReadAllText(filePath);
        Athlete deserialized = JsonSerializer.Deserialize<Athlete>(json);
        Logging.Log($"{deserialized.TemperatureSuitability}");
        return deserialized;
    }
}