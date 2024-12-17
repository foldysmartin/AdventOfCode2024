using System.Collections.Immutable;

public class Day2Test
{
    [Fact]
    public void TestDecreasingByUpToThreeIsSafe()
    {
        var report = new List<int> { 7, 6, 4, 2, 1 }.ToImmutableList();
        Assert.True(Day2.IsSafe(report));
    }

    [Fact]
    public void TestDecreasingByMoreThanThreeIsNotSafe()
    {
        var report = new List<int> { 9, 7, 6, 2, 1 }.ToImmutableList();
        Assert.False(Day2.IsSafe(report));
    }

    [Fact]
    public void TestIncreasingByMoreThanThreeIsNotSafe()
    {
        var report = new List<int> { 1, 2, 7, 8, 9 }.ToImmutableList();
        Assert.False(Day2.IsSafe(report));
    }

    [Fact]
    public void TestIncreasingByUpToThreeIsSafe()
    {
        var report = new List<int> { 1, 3, 6, 7, 9 }.ToImmutableList();
        Assert.True(Day2.IsSafe(report));
    }

    [Fact]
    public void NeitherIncreasingOrDecreasingIsUnsafe()
    {
        var report = new List<int> { 8, 6, 4, 4, 1 }.ToImmutableList();
        Assert.False(Day2.IsSafe(report));
    }

    [Fact]
    public void ReportCannotContainBothIncreasingAndDecreasing()
    {
        var report = new List<int> { 1, 2, 4, 3, 5 }.ToImmutableList();
        Assert.False(Day2.IsSafe(report));
    }

    [Fact]
    public void ProblemDampnerCanRemoveOneValueToMakeItSafe()
    {

        var report = new List<int> { 1, 3, 2, 4, 6 }.ToImmutableList();
        var report2 = new List<int> { 8, 6, 4, 4, 1 }.ToImmutableList();
        var report3 = new List<int> { 35, 37, 38, 41, 43, 41 }.ToImmutableList();

        //Assert.True(Day2.ProblemDampner(report));
        //Assert.True(Day2.ProblemDampner(report2));
        Assert.True(Day2.ProblemDampner(report3));
    }

    [Fact]
    public void ProblemDampnerCannotRemoveMultipleValuesToMakeItSafe()
    {
        var report = new List<int> { 8, 4, 4, 4, 1 }.ToImmutableList();

        Assert.False(Day2.ProblemDampner(report));
    }
}