using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using IPL_Censorship_Analyzer.Models;

namespace IPL_Censorship_Analyzer.Services
{
    public static class JsonHandler
    {
        public static List<IplMatch> ReadJson(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<IplMatch>>(json);
        }

        public static void WriteJson(string path, List<IplMatch> matches)
        {
            string json = JsonConvert.SerializeObject(matches, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
