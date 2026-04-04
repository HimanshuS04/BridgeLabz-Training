using System.Collections.Generic;
using IPL_Censorship_Analyzer.Models;

namespace IPL_Censorship_Analyzer.Services
{
    public static class CensorshipService
    {
        public static string MaskTeamName(string team)
        {
            var parts = team.Split(' ');
            if (parts.Length > 1)
                parts[1] = "***";
            return string.Join(" ", parts);
        }

        public static void ApplyCensorship(IplMatch match)
        {
            string maskedTeam1 = MaskTeamName(match.team1);
            string maskedTeam2 = MaskTeamName(match.team2);

            var newScore = new Dictionary<string, int>();
            foreach (var entry in match.score)
            {
                newScore[MaskTeamName(entry.Key)] = entry.Value;
            }

            match.team1 = maskedTeam1;
            match.team2 = maskedTeam2;
            match.winner = MaskTeamName(match.winner);
            match.player_of_match = "REDACTED";
            match.score = newScore;
        }
    }
}
