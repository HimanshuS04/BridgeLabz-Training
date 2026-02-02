using IPL_Censorship_Analyzer.Services;

class Program
{
    static void Main()
    {
        var jsonMatches = JsonHandler.ReadJson("input.json");
        foreach (var match in jsonMatches)
            CensorshipService.ApplyCensorship(match);
        JsonHandler.WriteJson("censored.json", jsonMatches);

        var csvMatches = CsvHandler.ReadCsv("input.csv");
        foreach (var match in csvMatches)
            CensorshipService.ApplyCensorship(match);
        CsvHandler.WriteCsv("censored.csv", csvMatches);

        System.Console.WriteLine("Censorship completed successfully!");
    }
}
