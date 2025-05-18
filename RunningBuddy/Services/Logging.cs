using System;
using System.IO;

namespace RunningBuddy.Services;

public static class Logging
{
    private static StreamWriter? _logWriter;

    private static string? _dateTimeToString;
    private static string? _filePath;
    private static string? _directoryPath;

    private static DirectoryInfo _directoryInfo;

    // This is just an entry point inside which are some basic variables set
    public static void Entry()
    {
        _dateTimeToString = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        _directoryPath = "Logs";
        _filePath = "Logs/Log-" + _dateTimeToString + ".txt";

        InstanceCreation();
    }

    // Creates the instance of StreamWriter for following logging and the folder for logs
    private static void InstanceCreation()
    {
        if (!DoesDirectoryExist())
        {
            _directoryInfo = Directory.CreateDirectory(_directoryPath);
        }
        _logWriter = new StreamWriter(_filePath, true);
        _logWriter.AutoFlush = true;
    }

    // Checks if folder exists
    private static bool DoesDirectoryExist()
    {
        if (Directory.Exists(_directoryPath))
            return true;

        return false;
    }

    // Checks if the folder exists after that creates a log message
    public static void Log(string message)
    {
        if (DoesDirectoryExist())
        {
            _dateTimeToString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logMessage = _dateTimeToString + " - " + message;
            _logWriter.WriteLine(logMessage);
        }
    }
}
