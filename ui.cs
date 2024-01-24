using System;
using DuckOS.Core;
using Sys = Cosmos.System;

namespace DuckOS.UI
{
    public class ui
    {
        private int selectedIndex = 0;

        public void run()
        {
            var MSK = 1.1;
            string[] options = { "echo", "About", "calculator", "Shutdown", "restart into Shell" };

            Console.CursorVisible = false;

            while (true)
            {
                Console.Clear();
                DisplayOptions(options);

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = Math.Max(0, selectedIndex - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = Math.Min(options.Length - 1, selectedIndex + 1);
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        if (selectedIndex == 0)
                        {
                            Console.Write("echo> ");
                            var input = Console.ReadLine();
                            Console.WriteLine(input);
                        }
                        else if (selectedIndex == 1)
                        {
                            Console.WriteLine("OS: DuckOS 23H1");
                            Console.WriteLine("CodeName: Pluto");
                            Console.WriteLine($"MSK/MicroSaveKernel: {MSK}");
                            Console.WriteLine("Created In C#");
                        }
                        else if (selectedIndex == 2)
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
                        else if (selectedIndex == 3)
                        {
                            Sys.Power.Shutdown();
                        }
                        else if (selectedIndex == 4)
                        {
                            Sys.Power.Reboot();
                        }

                        Console.ReadKey();
                        break;
                }
            }
        }

        private void DisplayOptions(string[] options)
        {
            Console.WriteLine($"Current Time: {DateTime.Now.ToString("HH:mm:ss")}");
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.WriteLine(options[i]);

                Console.ResetColor();
            }
        }
    }
}
