using System.Collections.Generic;

namespace IPL_Censorship_Analyzer.Models
{
    public class IplMatch
    {
        public int match_id { get; set; }
        public required string team1 { get; set; }
        public required string team2 { get; set; }
        public required Dictionary<string, int> score { get; set; }
        public required string winner { get; set; }
        public required string player_of_match { get; set; }
    }
}
