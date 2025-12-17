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
            ///// How to access a JSON file from a URL/////
            WebClient client = new WebClient();
            string urlPath = client.DownloadString("https://site.api.espn.com/apis/site/v2/sports/football/nfl/scoreboard");

            dynamic dynamicObj = JsonConvert.DeserializeObject<dynamic>(urlPath);

            var events = dynamicObj["events"] as JArray;

            foreach (var item in events)
            {
                var name = item["name"]?.ToString();
                var shortName = item["shortName"]?.ToString();
                Console.WriteLine($"{name} // {shortName}\n");
            }
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
