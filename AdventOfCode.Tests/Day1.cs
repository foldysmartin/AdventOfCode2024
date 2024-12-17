using System.Collections.Immutable;
using Xunit;


public class Day1Tests
{
    [Fact]
    public void LocationDistanceIsCalculated()
    {
        var firstList = new List<int> { 3, 4, 2, 1, 3, 3 }.ToImmutableList();
        var secondList = new List<int> { 4, 3, 5, 3, 9, 3 }.ToImmutableList();

        var expected = 11;

        Assert.Equal(expected, Day1.CalculateDistance(firstList, secondList));
    }

    [Fact]
    public void SimilarityScore()
    {
        var firstList = new List<int> { 3, 4, 2, 1, 3, 3 }.ToImmutableList();
        var secondList = new List<int> { 4, 3, 5, 3, 9, 3 }.ToImmutableList();

        var expected = 31;

        Assert.Equal(expected, Day1.CalculateSimilarity(firstList, secondList));
    }
}
