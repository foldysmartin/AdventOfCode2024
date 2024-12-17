using System.Collections.Immutable;

public class Day2
{
    public static bool ProblemDampner(ImmutableList<int> report)
    {
        if (IsSafe(report))
        {
            return true;
        }
        else
        {
            for (int i = 0; i < report.Count; i++)
            {
                var newReport = report.RemoveAt(i);
                if (IsSafe(newReport))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public static bool IsSafe(ImmutableList<int> report)
    {
        return IsSafelyIncreasing(report) || IsSafelyDecreasing(report);
    }

    private static bool IsSafelyIncreasing(ImmutableList<int> report)
    {
        return report.Zip(report.Skip(1)).All(pair => pair.Second - pair.First >= 1 && pair.Second - pair.First <= 3);
    }

    private static bool IsSafelyDecreasing(ImmutableList<int> report)
    {
        return report.Zip(report.Skip(1)).All(pair => pair.First - pair.Second >= 1 && pair.First - pair.Second <= 3);
    }
}