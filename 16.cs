using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class IPLCensorship
{
    static void Main()
    {

        Console.Write("Enter IPL JSON File Path: ");
        string jsonPath = Console.ReadLine();

        if (File.Exists(jsonPath))
        {
            string jsonData = File.ReadAllText(jsonPath);
            JArray matches = JArray.Parse(jsonData);

            foreach (var match in matches)
            {
                match["team1"] = CensorTeamName(match["team1"].ToString());
                match["team2"] = CensorTeamName(match["team2"].ToString());
                match["player_of_match"] = "REDACTED";
            }

            File.WriteAllText("Censored_IPL.json", matches.ToString(Formatting.Indented));
            Console.WriteLine("\n Censored JSON saved as Censored_IPL.json");
        }
        else
        {
            Console.WriteLine(" JSON File Not Found!");
        }

        
        Console.Write("\nEnter IPL CSV File Path: ");
        string csvPath = Console.ReadLine();

        if (File.Exists(csvPath))
        {
            var lines = File.ReadAllLines(csvPath);
            var header = lines[0].Split(',');
            List<string> newCsv = new List<string> { string.Join(",", header) };

            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                values[1] = CensorTeamName(values[1]); // team1
                values[2] = CensorTeamName(values[2]); // team2
                values[3] = "REDACTED"; // Player of the Match
                newCsv.Add(string.Join(",", values));
            }

            File.WriteAllLines("Censored_IPL.csv", newCsv);
            Console.WriteLine("\n Censored CSV saved as Censored_IPL.csv");
        }
        else
        {
            Console.WriteLine(" CSV File Not Found!");
        }
    }

    static string CensorTeamName(string team)
    {
        var parts = team.Split(' ');
        if (parts.Length > 1)
            parts[1] = "***";
        return string.Join(" ", parts);
    }
}
