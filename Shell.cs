using System;
using System.Threading;
using Sys = Cosmos.System;
using DuckOS.UI;
using System.Linq;

namespace DuckOS.Core
{
    public class shell
    {
        private Cat32 cat32Instance = new Cat32(); // Instantiate Cat32 instance
        private ScriptingEngine scriptingEngine = new ScriptingEngine(); // EScript / exe support

        public void run()
        {
            var MSK = 1.1;
            try
            {
                Console.Write("> ");
                var input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "exit":
                    case "shutdown":
                        Sys.Power.Shutdown();
                        break;

                    case "restart":
                    case "reboot":
                        Sys.Power.Reboot();
                        break;

                    case "about":
                    case "info":
                        DisplayAboutInfo(MSK);
                        break;

                    case "cls":
                    case "clear":
                        Console.Clear();
                        break;

                    case var _ when input.StartsWith("echo "):
                        Console.WriteLine(input.Substring(5));
                        break;

                    case "time":
                        DisplayCurrentTime();
                        break;

                    case "theam-cyan":
                        ChangeConsoleTheme();
                        break;

                    case "devcrash":
                        SimulateSystemCrash();
                        break;

                    case "ui":
                        LaunchUI();
                        break;

                    case "calc":
                        PerformCalculation();
                        break;

                    case var _ when input.StartsWith("mk ") || input.StartsWith("touch "):
                        CreateFile(input.Split(' ')[1]);
                        break;

                    case var _ when input.StartsWith("rm "):
                        DeleteFile(input.Split(' ')[1]);
                        break;

                    case var _ when input.StartsWith("mkdir ") || input.StartsWith("touchdir "):
                        CreateFolder(input.Split(' ')[1]);
                        break;

                    case var _ when input.StartsWith("rmdir "):
                        DeleteFolder(input.Split(' ')[1]);
                        break;

                    case var _ when input.StartsWith("write ") || input.StartsWith("puts "):
                        WriteToFile(input);
                        break;

                    case var _ when input.StartsWith("cat ") || input.StartsWith("read "):
                        ReadFile(input.Split(' ')[1]);
                        break;

                    case var _ when input.StartsWith("disk "):
                        ProcessDiskCommand(input.Split(' ')[1]);
                        break;

                    case "ls":
                        ListFilesAndFolders(@"0:\");
                        break;

                    case var _ when input.StartsWith("lsdir "):
                        ListFilesAndFolders(input.Split(' ')[1]);
                        break;
                    case var _ when input.StartsWith("savescript "):
                        SaveScriptToFile(input.Substring(11));
                        break;

                    case var _ when input.StartsWith("executescript "):
                        ExecuteScriptFromFile(input.Substring(14));
                        break;
                    case "help":
                        DisplayHelp();
                        break;
                    case "key":
                        ActivateProductKey();
                        break;

                    default:
                        Console.WriteLine($"Invalid Command \"{input}\"");
                        break;
                }
            }
            catch (Exception ex)
            {
                HandleCrash(ex);
            }
        }

        // Methods for each command...
        private void HandelWolFlyDriver(string ssid, string password, bool encryption)
        {
            
        }
        private void SaveScriptToFile(string filePath)
        {
            try
            {
                Console.WriteLine("Warning: in Bata, this does not work as of update 23H1");
                Console.Write("Enter script content> ");
                string script = Console.ReadLine();
                Console.Write("Enter path to script> ");
                string path = Console.ReadLine();
                cat32Instance.WriteScriptToFile(script, path); // Implement this method in Cat32 class
                Console.WriteLine($"Script saved to {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving script: {ex.Message}");
            }
        }
        private void ActivateProductKey()
        {
            // just for fun
            Console.Write("Enter product key> ");
            string productKey = Console.ReadLine();
            Console.WriteLine($"Product key '{productKey}' activated successfully!");
        }

        private void ExecuteScriptFromFile(string filePath)
        {
            Console.WriteLine("Warning: in Bata, this does not work as of update 23H1");
            scriptingEngine.ExecuteScriptFromFile(filePath);
        }

        private void DisplayAboutInfo(double MSK)
        {
            Console.WriteLine("OS: DuckOS 23H1");
            Console.WriteLine("CodeName: Pluto");
            Console.WriteLine($"MSK/MicroSaveKernel: {MSK}");
            Console.WriteLine("Created In C#");
        }

        private void DisplayCurrentTime()
        {
            Console.WriteLine($"Current Time: {DateTime.Now.ToString("HH:mm:ss")}");
        }

        private void ChangeConsoleTheme()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
        }

        private void SimulateSystemCrash()
        {
            throw new Exception("0x00");
        }

        private void LaunchUI()
        {
            DuckOS.UI.ui uiInstance = new DuckOS.UI.ui();
            uiInstance.run();
        }

        private void PerformCalculation()
        {
            Console.Write("Number1> ");
            var aStr = Console.ReadLine();
            Console.Write("Number2> ");
            var bStr = Console.ReadLine();
            Console.Write("Operator> ");
            var c = Console.ReadLine();

            if (double.TryParse(aStr, out double a) && double.TryParse(bStr, out double b))
            {
                switch (c)
                {
                    case "+":
                        Console.WriteLine(a + b);
                        break;
                    case "-":
                        Console.WriteLine(a - b);
                        break;
                    case "/":
                        Console.WriteLine(a / b);
                        break;
                    case "*":
                        Console.WriteLine(a * b);
                        break;
                    case "%":
                        Console.WriteLine(a % b);
                        break;
                    default:
                        Console.WriteLine($"Invalid Operator \"{c}\"");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter valid numeric values.");
            }
        }

        private void CreateFile(string filename)
        {
            try
            {
                cat32Instance.CreateFile(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating the file: {ex.Message}");
            }
        }

        private void DeleteFile(string filename)
        {
            try
            {
                cat32Instance.DeleteFile(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting the file: {ex.Message}");
            }
        }

        private void CreateFolder(string filename)
        {
            try
            {
                cat32Instance.CreateFolder(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating the folder: {ex.Message}");
            }
        }

        private void DeleteFolder(string filename)
        {
            try
            {
                cat32Instance.DeleteFolder(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting the folder: {ex.Message}");
            }
        }

        private void WriteToFile(string input)
        {
            var inputParts = input.Split(' ');
            if (inputParts.Length >= 3)
            {
                var filename = inputParts[1];
                var text = string.Join(" ", inputParts.Skip(2));

                try
                {
                    cat32Instance.Write(filename, text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to the file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Usage: Write filename text");
            }
        }

        private void ReadFile(string filename)
        {
            try
            {
                cat32Instance.Read(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }
        }

        private void ProcessDiskCommand(string command)
        {
            try
            {
                if (command == "info")
                {
                    cat32Instance.info();
                }
                if (command == "Reset")
                {
                    Console.WriteLine("DeleteDisk, all files, all folders, all programs, all data");
                    Console.Write("Y/n> ");
                    var yn = Console.ReadLine();
                    if (yn == "y" || yn == "Y")
                    {
                        cat32Instance.Erase();
                    }
                    else
                    {
                        Console.WriteLine("Not Erasing");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing disk command: {ex.Message}");
            }
        }

        private void ListFilesAndFolders(string path)
        {
            try
            {
                cat32Instance.list(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void DisplayHelp()
        {
            Console.WriteLine("DuckOS Shell Help:");
            Console.WriteLine("  exit | shutdown - Shut down the operating system");
            Console.WriteLine("  restart | reboot - Restart the operating system");
            Console.WriteLine("  about | info - Display information about DuckOS");
            Console.WriteLine("  cls | clear - Clear the console screen");
            Console.WriteLine("  echo <text> - Print the specified text to the console");
            Console.WriteLine("  time - Display the current time");
            Console.WriteLine("  theam-cyan - Change the console theme to cyan");
            Console.WriteLine("  DevCrash - Simulate a system crash for development purposes");
            Console.WriteLine("  ui - Launch the UI");
            Console.WriteLine("  calc - Perform basic arithmetic calculations");
            Console.WriteLine("  ls - List files and folders in the root directory");
            Console.WriteLine("  mk <filename> | touch <filename> - Create a new file");
            Console.WriteLine("  rm <filename> - Delete a file");
            Console.WriteLine("  mkdir <directory> | touchdir <directory> - Create a new folder");
            Console.WriteLine("  rmdir <directory> - Delete a folder");
            Console.WriteLine("  Write <filename> | puts <filename> <text> - Write text to a file");
            Console.WriteLine("  cat <filename> | read <filename> - Read the contents of a file");
            Console.WriteLine("  disk info - Display information about the Cat32 filesystem");
            Console.WriteLine("  disk Reset - Delete all files, folders, programs, and data");
            Console.WriteLine("  ls - List files and folders in the root directory");
            Console.WriteLine("  lsdir <directory> - List files and folders in the specified directory");
        }

        private void HandleCrash(Exception ex)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("DuckOS Crashed And Needs To Restart");
            Console.WriteLine("");
            Console.WriteLine("We Are Sorry For The Crash");
            Console.WriteLine("");
            Console.WriteLine("Support: GoToMyGitHub");
            Console.WriteLine($"Error Code: {ex.Message}");
            Console.Beep();
            Thread.Sleep(6500);
            Console.Beep();
            Sys.Power.Reboot();
        }
    }
}
