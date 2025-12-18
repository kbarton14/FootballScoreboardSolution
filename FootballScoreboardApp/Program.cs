using ConsoleTables;
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
                            GetNFLScores();
                            break;
                        case 2:
                            GetNBAScores();
                            break;
                        case 3:
                            GetLaLigaScores();
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

        public static void GetNFLScores()
        {
            ///// How to access a JSON file from an API endpoint/////
            WebClient client = new WebClient();
            string urlPath = client.DownloadString("https://site.api.espn.com/apis/site/v2/sports/football/nfl/scoreboard");

            dynamic dynamicObj = JsonConvert.DeserializeObject<dynamic>(urlPath);

            var events = dynamicObj["events"] as JArray;

            var table = new ConsoleTable("Status", "Time", "Matchup", "Broadcast", "Score", "Moneyline", "Venue");
            foreach (var item in events)
            {
                var shortName = item["shortName"]?.ToString();
                var time = (DateTime)item["competitions"]?[0]["date"];
                DateTime dateTime = TimeZoneInfo.ConvertTimeToUtc(time);

                var broadcast = item["competitions"]?[0]?["broadcasts"]?.FirstOrDefault()?["names"]?.FirstOrDefault()?.ToString() ?? "N/A";
                var moneyline = item["competitions"]?[0]?["odds"]?.FirstOrDefault()?["details"]?.ToString() ?? "N/A";
                var gameStatus = item["competitions"][0]["status"]["type"]["description"]?.ToString();

                var awayScore = item["competitions"]?[0]?["competitors"]?.FirstOrDefault(c => c["homeAway"]?.ToString() == "away")?["score"]?.ToString() ?? "0";
                var homeScore = item["competitions"]?[0]?["competitors"]?.FirstOrDefault(c => c["homeAway"]?.ToString() == "home")?["score"]?.ToString() ?? "0";
                var scoreDisplay = $"{awayScore} - {homeScore}";

                var venue = item["competitions"]?[0]?["venue"]?["fullName"]?.ToString() ?? "N/A";

                table.AddRow(gameStatus, time, shortName, broadcast, scoreDisplay, moneyline, venue);
            }
            table.Write();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Press enter to return to the main menu...");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }
        public static void GetNBAScores()
        {
            ///// How to access a JSON file from an API endpoint/////
            WebClient client = new WebClient();
            string urlPath = client.DownloadString("https://site.api.espn.com/apis/site/v2/sports/basketball/nba/scoreboard");

            dynamic dynamicObj = JsonConvert.DeserializeObject<dynamic>(urlPath);

            var events = dynamicObj["events"] as JArray;

            var table = new ConsoleTable("Status", "Time", "Matchup", "Broadcast", "Score", "Moneyline", "Venue");
            foreach (var item in events)
            {
                var shortName = item["shortName"]?.ToString();
                var time = (DateTime)item["competitions"]?[0]["date"];
                DateTime dateTime = TimeZoneInfo.ConvertTimeToUtc(time);

                var broadcast = item["competitions"]?[0]?["broadcasts"]?.FirstOrDefault()?["names"]?.FirstOrDefault()?.ToString() ?? "N/A";
                var moneyline = item["competitions"]?[0]?["odds"]?.FirstOrDefault()?["details"]?.ToString() ?? "N/A";
                var gameStatus = item["competitions"][0]["status"]["type"]["description"]?.ToString();

                var awayScore = item["competitions"]?[0]?["competitors"]?.FirstOrDefault(c => c["homeAway"]?.ToString() == "away")?["score"]?.ToString() ?? "0";
                var homeScore = item["competitions"]?[0]?["competitors"]?.FirstOrDefault(c => c["homeAway"]?.ToString() == "home")?["score"]?.ToString() ?? "0";
                var scoreDisplay = $"{awayScore} - {homeScore}";

                var venue = item["competitions"]?[0]?["venue"]?["fullName"]?.ToString() ?? "N/A";

                table.AddRow(gameStatus, time, shortName, broadcast, scoreDisplay, moneyline, venue);
            }
            table.Write();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Press enter to return to the main menu...");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }
        public static void GetLaLigaScores()
        {
            ///// How to access a JSON file from an API endpoint/////
            WebClient client = new WebClient();
            string urlPath = client.DownloadString("https://site.api.espn.com/apis/site/v2/sports/soccer/esp.1/scoreboard");

            dynamic dynamicObj = JsonConvert.DeserializeObject<dynamic>(urlPath);

            var events = dynamicObj["events"] as JArray;

            var table = new ConsoleTable("Status", "Time", "Matchup", "Broadcast", "Score", "Moneyline", "Venue");
            foreach (var item in events)
            {
                var shortName = item["shortName"]?.ToString();
                var time = (DateTime)item["competitions"]?[0]["date"];
                DateTime dateTime = TimeZoneInfo.ConvertTimeToUtc(time);

                var broadcast = item["competitions"]?[0]?["broadcasts"]?.FirstOrDefault()?["names"]?.FirstOrDefault()?.ToString() ?? "N/A";
                var moneyline = item["competitions"]?[0]?["odds"]?.FirstOrDefault()?["details"]?.ToString() ?? "N/A";
                var gameStatus = item["competitions"][0]["status"]["type"]["description"]?.ToString();

                var awayScore = item["competitions"]?[0]?["competitors"]?.FirstOrDefault(c => c["homeAway"]?.ToString() == "away")?["score"]?.ToString() ?? "0";
                var homeScore = item["competitions"]?[0]?["competitors"]?.FirstOrDefault(c => c["homeAway"]?.ToString() == "home")?["score"]?.ToString() ?? "0";
                var scoreDisplay = $"{awayScore} - {homeScore}";

                var venue = item["competitions"]?[0]?["venue"]?["fullName"]?.ToString() ?? "N/A";

                table.AddRow(gameStatus, time, shortName, broadcast, scoreDisplay, moneyline, venue);
            }
            table.Write();
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


        ///// How to access a local JSON file/////
        //static void Main(string[] args)
        //{
        //    // Path to the JSON file
        //    string filePath = "scoreboard.json";

        //    // Read the entire content of the JSON file into a string
        //    var json = File.ReadAllText(filePath);

        //    // Parse the JSON string into a JObject
        //    var data = JObject.Parse(json);

        //    var events = data["events"] as JArray;

        //    foreach (var item in events)
        //    {
        //        var name = item["name"]?.ToString();
        //        Console.WriteLine(name);
        //    }


        //}
    }
}
