using System.Collections.Generic;
using System.IO;
using IPL_Censorship_Analyzer.Models;

namespace IPL_Censorship_Analyzer.Services
{
    public static class CsvHandler
    {
        public static List<IplMatch> ReadCsv(string path)
        {
            var lines = File.ReadAllLines(path);
            var matches = new List<IplMatch>();

            for (int i = 1; i < lines.Length; i++)
            {
                var cols = lines[i].Split(',');

                matches.Add(new IplMatch
                {
                    match_id = int.Parse(cols[0]),
                    team1 = cols[1],
                    team2 = cols[2],
                    score = new Dictionary<string, int>
                    {
                        { cols[1], int.Parse(cols[3]) },
                        { cols[2], int.Parse(cols[4]) }
                    },
                    winner = cols[5],
                    player_of_match = cols[6]
                });
            }
            return matches;
        }

        public static void WriteCsv(string path, List<IplMatch> matches)
        {
            using var writer = new StreamWriter(path);
            writer.WriteLine("match_id,team1,team2,score_team1,score_team2,winner,player_of_match");

            foreach (var m in matches)
            {
                var scores = new List<int>(m.score.Values);
                writer.WriteLine($"{m.match_id},{m.team1},{m.team2},{scores[0]},{scores[1]},{m.winner},{m.player_of_match}");
            }
        }
    }
}
