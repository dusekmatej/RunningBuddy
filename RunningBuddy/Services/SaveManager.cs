using System.Text.Json;


namespace RunningBuddy.Services;

public class SaveManager
{

    private string _folder;

    // Constructor
    public SaveManager(string folderPath)
    {
        _folder = folderPath;
    }

    // Checks if the user save file exists
    public bool DoesFileExist(string filePath)
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
    public bool DoesDirectoryExist(string directoryPath)
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
    
    // Saves both athletes into JSON
    public void SaveAthletes(Athlete athlete0, Athlete athlete1)
    {
        Save(athlete0, "Users/user0.json");
        Save(athlete1, "Users/user1.json");
    }

    
    // Saves one athlete 
    private void Save(Athlete athlete, string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(athlete, options);
        File.WriteAllText(filePath, json);
    }

    // Loads an athlete from a JSON file 
    public Athlete Load(string filePath)
    {
        AppState.Athlete0Entered = true;
        AppState.Athlete1Entered = true;
        
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

    // Delete only one athlete

    public void DeleteAthlete(string athletePath)
    {
        if (DoesFileExist(athletePath))
        {
            File.Delete(athletePath);
        }
    }
    
    // Deletes both athletes 
    public void DeleteAthletes()
    {
        if (DoesDirectoryExist(_folder))
        {
            Logging.Log("Deleting athletes");
            if (DoesFileExist("Users/user0.json"))
            {
                File.Delete("Users/user0.json");
            }

            if (DoesFileExist("Users/user1.json"))
            {
                File.Delete("Users/user1.json");
            }
        }
    }

}