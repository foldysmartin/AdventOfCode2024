using System.Collections.Immutable;

public static class Day1
{
    public static int CalculateDistance(ImmutableList<int> firstList, ImmutableList<int> secondList)
    {
        firstList = firstList.Sort();
        secondList = secondList.Sort();

        return firstList.Zip(secondList).Sum(pair => Math.Abs(pair.First - pair.Second));
    }

    public static int CalculateSimilarity(ImmutableList<int> firstList, ImmutableList<int> secondList)
    {
        firstList = firstList.Sort();
        secondList = secondList.Sort();

        return firstList.Select((value) => secondList.Count(value.Equals) * value).Sum();
    }
}