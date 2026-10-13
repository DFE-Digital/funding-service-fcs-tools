namespace BuildLogReader
{
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllLines("Passed.txt", File.ReadAllLines(args.First()).Where(line => line.Contains("Passed   ") && !line.Contains("|")));
            File.WriteAllLines("Failed.txt", File.ReadAllLines(args.First()).Where(line => line.Contains("Failed   ") && !line.Contains("|")));
        }
    }
}
