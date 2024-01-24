using DuckOS.Core;
using System;
using System.IO;

public class ScriptingEngine
{
    private Cat32 cat32Instance = new Cat32();

    public void SaveScriptToFile(string script, string filePath)
    {
        try
        {
            File.WriteAllText(filePath, script);
            Console.WriteLine($"Script saved to {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving script: {ex.Message}");
        }
    }

    public void ExecuteScriptFromFile(string filePath)
    {
        try
        {
            string script = File.ReadAllText(filePath);
            ExecuteScript(script);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing script from file: {ex.Message}");
        }
    }

    public void ExecuteScript(string script)
    {
        try
        {
            var commands = script.Split('\n'); // Split script into lines (assuming each line is a command)

            foreach (var command in commands)
            {
                ExecuteCommand(command.Trim()); // Trim to remove leading/trailing whitespaces
            }

            Console.WriteLine($"Script executed successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing script: {ex.Message}");
        }
    }

    private void ExecuteCommand(string command)
    {
        try
        {
            // Execute the command using your existing logic
            // Modify as needed based on the structure of your commands
            // Example:
            if (command.StartsWith("echo "))
            {
                Console.WriteLine(command.Substring(5));
            }
            else if (command.StartsWith("write "))
            {
                // Implement write logic
            }
            else if (command.StartsWith("cat "))
            {
                // Implement cat logic
            }
            // Add more commands as needed
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing command: {ex.Message}");
        }
    }
}

