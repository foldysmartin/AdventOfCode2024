using System.Text.RegularExpressions;

public static class Day3
{
    public static int CalculateFromCorruptedMemory(string memory)
    {
        var parameters = Day3Parser.RemoveDisabledMemory(memory).SelectMany(Day3Parser.FromCorruptedMemory);
        return Day3Calculator.Multiply(parameters);
    }
}

public static class Day3Parser
{
    public static List<string> RemoveDisabledMemory(string memory)
    {
        return FilterByDosAndDonts(memory).ToList();

    }

    private static IEnumerable<string> FilterByDosAndDonts(string memory)
    {
        var chunks = memory.Split("do()");

        foreach (var chunk in chunks)
        {
            if (chunk.Contains("don't()"))
            {
                yield return chunk.Split("don't()")[0];
            }
            else
            {
                yield return chunk;
            }
        }
    }

    public static List<Tuple<int, int>> FromCorruptedMemory(string input)
    {
        var result = new List<Tuple<int, int>>();
        var pattern = new Regex(@"mul\((\d+),(\d+)\)");
        foreach (Match match in pattern.Matches(input))
        {
            result.Add(Tuple.Create(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value)));
        }
        return result;
    }
}

public static class Day3Calculator
{

    public static int Multiply(IEnumerable<Tuple<int, int>> memory)
    {
        return memory.Aggregate(0, (acc, tuple) => acc + tuple.Item1 * tuple.Item2);
    }
}