using ConsoleTables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FootballScoreboardApp
{
    internal static class API
    {
        //public static void GetScores(string url)
        //{
        //    WebClient client = new WebClient();
        //    string urlPath = client.DownloadString(url);

        //    dynamic dynamicObj = JsonConvert.DeserializeObject<dynamic>(urlPath);

        //    var events = dynamicObj["events"] as JArray;

        //    var table = new ConsoleTable("Status", "Time", "Matchup", "Broadcast", "Score", "Moneyline", "Venue");
        //    foreach (var item in events)
        //    {
        //        var shortName = item["shortName"]?.ToString();
        //        var time = (DateTime)item["competitions"]?[0]["date"];

        //        var broadcast = item["competitions"]?[0]?["broadcasts"]?.FirstOrDefault()?["names"]?.FirstOrDefault()?.ToString() ?? "N/A";
        //        var moneyline = item["competitions"]?[0]?["odds"]?.FirstOrDefault()?["details"]?.ToString() ?? "N/A";
        //        var gameStatus = item["competitions"][0]["status"]["type"]["description"]?.ToString();

        //        var awayScore = item["competitions"]?[0]?["competitors"]?.FirstOrDefault(c => c["homeAway"]?.ToString() == "away")?["score"]?.ToString() ?? "0";
        //        var homeScore = item["competitions"]?[0]?["competitors"]?.FirstOrDefault(c => c["homeAway"]?.ToString() == "home")?["score"]?.ToString() ?? "0";
        //        var scoreDisplay = $"{awayScore} - {homeScore}";

        //        var venue = item["competitions"]?[0]?["venue"]?["fullName"]?.ToString() ?? "N/A";

        //        table.AddRow(gameStatus, time, shortName, broadcast, scoreDisplay, moneyline, venue);
        //    }
        //    table.Write();
        //}

        public static async Task GetScores(string url)
        {
            using HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string urlPath = await response.Content.ReadAsStringAsync();

            dynamic dynamicObj = JsonConvert.DeserializeObject<dynamic>(urlPath);

            var events = dynamicObj["events"] as JArray;

            var table = new ConsoleTable("Status", "Time", "Matchup", "Broadcast", "Score", "Moneyline", "Venue");
            foreach (var item in events)
            {
                var shortName = item["shortName"]?.ToString();
                var time = (DateTime)item["competitions"]?[0]["date"];

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
        }
    }
    public static class Urls
    {
        public const string NFL = "https://site.api.espn.com/apis/site/v2/sports/football/nfl/scoreboard";
        public const string NBA = "https://site.api.espn.com/apis/site/v2/sports/basketball/nba/scoreboard";
        public const string LALIGA = "https://site.api.espn.com/apis/site/v2/sports/soccer/esp.1/scoreboard";
    }

}
