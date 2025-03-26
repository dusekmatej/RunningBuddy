namespace RunningBuddy;

public class SaveManager
{
    public void DoesExist()
    {
        string pathUser1 = "saveU0.txt";
        string pathUser2 = "saveU1.txt";
        
        if (!File.Exists(pathUser1))
            CreateFile(pathUser1);
        else
            Load(pathUser1);
        
        if (!File.Exists(pathUser2))
            CreateFile(pathUser2);
        else
            Load(pathUser2);
    }
    
    public void CreateFile(string fileName)
    {
        File.WriteAllText(fileName, string.Empty);
    }
    
    public void Save(string fileName)
    {
        
    }

    public void Load(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
    }
}