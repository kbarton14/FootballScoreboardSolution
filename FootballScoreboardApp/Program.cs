using ConsoleTables;
using FootballScoreboardApp.DataStructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;

namespace FootballScoreboardApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Main Menu
            Console.ForegroundColor = ConsoleColor.White;
            string welcomeMessage = "Welcome to the Sports Scores Application!";
            string decorativeLine = new string('*', welcomeMessage.Length);
            int choice = 0;

            Console.WriteLine(decorativeLine);
            Console.WriteLine(welcomeMessage);
            Console.WriteLine(decorativeLine);

            do
            {
                Console.WriteLine("\n1. Display NFL Scores");
                Console.WriteLine("2. Display NBA Scores");
                Console.WriteLine("3. Display LaLiga Scores");
                Console.WriteLine("4. Exit Application");
                Console.Write("\nPlease select one of the above options: ");
                try
                {
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            ShowScores(Urls.NFL);
                            break;
                        case 2:
                            ShowScores(Urls.NBA);
                            break;
                        case 3:
                            ShowScores(Urls.LALIGA);
                            break;
                        case 4:
                            Exit();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please select a valid option.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("String inputs are not accepted. Please try again.");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Clear();
            } while (true);
        }

        public static void ShowScores(string url)
        {
            API.GetScores(url);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Press enter to return to the main menu...");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }
        static public void Exit()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("You are now exiting the application. Press enter to exit...");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
