using System;
using System.IO;

namespace RunningBuddy.Services;

public static class Logging
{
    private static StreamWriter _logWriter;

    private static string _dateTimeToString; 
    private static string _filePath;
    
    public static void Entry()
    {
        _dateTimeToString = DateTime.Now.ToString("ss-mm-hh-dd-MM-yyyy");
        
        _filePath = "Logs/Log-" + _dateTimeToString + ".txt";
        
        Console.WriteLine(_filePath);
        InstanceCreation();
    }
    
    private static void InstanceCreation()
    {
        Console.WriteLine("Instance created");
        _logWriter = new StreamWriter(_filePath, true);
        _logWriter.AutoFlush = true;
    }

    public static void Log(string message)
    {
        _dateTimeToString = DateTime.Now.ToString("ss-mm-hh-dd-MM-yyyy");
        
        string logMessage = _dateTimeToString + " - " + message;
        
        _logWriter.WriteLine(logMessage);
    }
}
