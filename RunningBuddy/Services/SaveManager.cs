using System.Text.Json;
namespace RunningBuddy.Services;

public class SaveManager
{
    private readonly string _folder;

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
    
    // Saves one athlete 
    public void Save(Athlete athlete, string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(athlete, options);
        File.WriteAllText(filePath, json);
    }

    // Loads an athlete from a JSON file 
    public Athlete Load(string user)
    {
        string athleteJson = File.ReadAllText(_folder + user);
        Athlete loadedAthlete = JsonSerializer.Deserialize<Athlete>(athleteJson)!;
        
        return loadedAthlete;
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