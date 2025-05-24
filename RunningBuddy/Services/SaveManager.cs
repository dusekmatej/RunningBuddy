using System.Text.Json;


namespace RunningBuddy.Services;

public class SaveManager
{

    private const string Folder = "Users";
    
    // Checks if the user save file exists
    private bool DoesFileExist(string filePath)
    {
        if (File.Exists(filePath))
        {
            Logging.Log("File exists!");
            return true;
        }

        Logging.Log("File does not exist");
        return false;
    }

    // Checks if the directory for user saves exists
    private bool DoesDirectoryExist(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            Logging.Log("Directory found!");
            return true;
        }

        Directory.CreateDirectory(directoryPath);
        DoesDirectoryExist(directoryPath);
        return true;
    }
    
    // public Athlete LoadAthletes(Athlete athlete0, Athlete athlete1)
    // {
    //     if (DoesDirectoryExist(Folder) && DoesFileExist("Users/user0.json") && DoesFileExist("Users/user1.json"))
    //     {
    //         Logging.Log("-------------------------------------- Loading users");
    //         athlete0 = Load("Users/user0.json");
    //         athlete1 = Load("Users/user1.json");
    //         AppState.LoadAthletesToAppState(athlete0, athlete1);
    //         AppState.AthletesEntered = true;
    //     }
    // }

    public void SaveAthletes(Athlete athlete0, Athlete athlete1)
    {
        Save(athlete0, "Users/user0.json");
        Save(athlete1, "Users/user1.json");
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
        {
            Logging.Log("File does not exist!");
            throw new FileNotFoundException("File not found");
        }
        
        string userJson = File.ReadAllText(filePath);
        Athlete deserialized = JsonSerializer.Deserialize<Athlete>(userJson)!;
        
        Logging.Log($"{deserialized.Location}");
        return deserialized;
    }
}