public class Day3Tests()
{
    [Fact]
    public void TestCorruptedMemoryParsing()
    {
        var input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        var expected = new List<Tuple<int, int>>()
        {
            Tuple.Create(2, 4),
            Tuple.Create(5,5),
            Tuple.Create(11, 8),
            Tuple.Create(8, 5)
        };

        Assert.Equal(expected, Day3Parser.FromCorruptedMemory(input));
    }

    [Fact]
    public void TestMultiplication()
    {
        var input = new List<Tuple<int, int>>()
        {
            Tuple.Create(2, 4),
            Tuple.Create(5,5),
            Tuple.Create(11, 8),
            Tuple.Create(8, 5)
        };

        Assert.Equal(161, Day3Calculator.Multiply(input));
    }

    [Fact]
    public void TestMultiplicationOfCorruptedMemory()
    {
        var input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        Assert.Equal(161, Day3.CalculateFromCorruptedMemory(input));
    }

    [Fact]
    public void TestFilterMemoryByDoAndDont()
    {
        var input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        var expected = new List<string>(){
            "xmul(2,4)&mul[3,7]!^",
            "?mul(8,5))"
        };

        Assert.Equal(expected, Day3Parser.RemoveDisabledMemory(input));
    }
}