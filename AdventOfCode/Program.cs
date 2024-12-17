// See https://aka.ms/new-console-template for more information
using System.Collections.Immutable;

var days = new Dictionary<int, Action>
{
    { 2, RunDay2 },
    { 3, RunDay3 }
};

if (args.Length == 0)
{
    Console.WriteLine("Please provide a day number as an argument.");
    return;
}

if (int.TryParse(args[0], out int day) && days.ContainsKey(day))
{
    days[day]();
}
else
{
    Console.WriteLine("Invalid day number.");
}

static void RunDay2()
{
    var reports = File.ReadAllLines("inputs/Day2.txt").Select(line => line.Split(" ").Select(int.Parse).ToImmutableList());
    var errors = reports.Count(Day2.ProblemDampner);
    Console.WriteLine(errors);
}

static void RunDay3()
{
    var input = File.ReadAllText("inputs/Day3.txt");
    var result = Day3.CalculateFromCorruptedMemory(input);
    Console.WriteLine(result);
}