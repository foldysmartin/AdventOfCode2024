public class Day4Tests
{
    [Fact]
    public void TestCharIsConvertedToALetter()
    {
        Assert.Equal(Letters.A, Day4.ConvertToLetter('A').letter());
        Assert.Equal(Letters.X, Day4.ConvertToLetter('X').letter());
        Assert.Equal(Letters.M, Day4.ConvertToLetter('M').letter());
        Assert.Equal(Letters.S, Day4.ConvertToLetter('S').letter());
    }

    [Fact]
    public void TestLetterJoinedInAGrid()
    {
        var grid = new List<List<Letter>>()
        {
            new List<Letter> { new A(), new X(), new M() },
            new List<Letter> { new S(), new A(), new X() },
            new List<Letter> { new M(), new S(), new A() }
        };

        Assert.Equal(Letters.X, Day4.JoinGrid(grid)[0][0].Right?.letter());
        Assert.Equal(Letters.A, Day4.JoinGrid(grid)[0][0].RightDown?.letter());
        Assert.Equal(Letters.S, Day4.JoinGrid(grid)[0][0].Down?.letter());

        Assert.Equal(Letters.M, Day4.JoinGrid(grid)[0][1].Right?.letter());
        Assert.Equal(Letters.X, Day4.JoinGrid(grid)[0][1].RightDown?.letter());
        Assert.Equal(Letters.A, Day4.JoinGrid(grid)[0][1].Down?.letter());


    }

    [Fact]
    public void TestXmasFromLeftToRightIsFound()
    {
        var grid = new List<List<Letter>>()
        {
            new List<Letter> { new X(), new M(), new A(), new S() },
        };

        grid = Day4.JoinGrid(grid);

        Assert.Equal(1, Day4.XmasCount(grid));
    }

    [Fact]
    public void TestXmasFromRightToLeftIsFound()
    {
        var grid = new List<List<Letter>>()
        {
            new List<Letter> { new S(), new A(), new M(), new X() },
        };

        grid = Day4.JoinGrid(grid);

        Assert.Equal(1, Day4.XmasCount(grid));
    }

    [Fact]
    public void TestXmasFromTopToBottomIsFound()
    {
        var grid = new List<List<Letter>>()
        {
            new List<Letter> { new X() },
            new List<Letter> { new M() },
            new List<Letter> { new A() },
            new List<Letter> { new S() }
        };

        grid = Day4.JoinGrid(grid);

        Assert.Equal(1, Day4.XmasCount(grid));
    }

    [Fact]
    public void TestXmasFromBottomToTopIsFound()
    {
        var grid = new List<List<Letter>>()
        {
            new List<Letter> { new S() },
            new List<Letter> { new A() },
            new List<Letter> { new M() },
            new List<Letter> { new X() }
        };

        grid = Day4.JoinGrid(grid);

        Assert.Equal(1, Day4.XmasCount(grid));
    }

    [Fact]
    public void TestXmasFromTopLeftToBottomRightIsFound()
    {
        var grid = new List<List<Letter>>()
        {
            new List<Letter> { new X(), new X(), new X(), new X() },
            new List<Letter> { new X(), new M(), new X(), new X() },
            new List<Letter> { new X(), new X(), new A(), new X() },
            new List<Letter> { new X(), new X(), new X(), new S() }
        };

        grid = Day4.JoinGrid(grid);

        Assert.Equal(1, Day4.XmasCount(grid));
    }

    [Fact]
    public void TestXmasFromTopRightToBottomLeftIsFound()
    {
        var grid = new List<List<Letter>>()
        {
            new List<Letter> { new X(), new X(), new X(), new X() },
            new List<Letter> { new X(), new X(), new M(), new X() },
            new List<Letter> { new X(), new A(), new X(), new X() },
            new List<Letter> { new S(), new X(), new X(), new X() }
        };

        grid = Day4.JoinGrid(grid);

        Assert.Equal(1, Day4.XmasCount(grid));
    }

    [Fact]
    public void TestXmasFromBottomLeftToTopRightIsFound()
    {
        var grid = new List<List<Letter>>()
        {
            new List<Letter> { new X(), new X(), new X(), new S() },
            new List<Letter> { new X(), new X(), new A(), new X() },
            new List<Letter> { new X(), new M(), new M(), new X() },
            new List<Letter> { new X(), new X(), new X(), new X() }
        };

        grid = Day4.JoinGrid(grid);

        Assert.Equal(1, Day4.XmasCount(grid));
    }

    [Fact]
    public void TestXmasFromBottomRightToTopLeftIsFound()
    {
        var grid = new List<List<Letter>>()
        {
            new List<Letter> { new S(), new X(), new X(), new X() },
            new List<Letter> { new X(), new A(), new X(), new X() },
            new List<Letter> { new X(), new X(), new M(), new X() },
            new List<Letter> { new X(), new X(), new X(), new X() }
        };

        grid = Day4.JoinGrid(grid);

        Assert.Equal(1, Day4.XmasCount(grid));
    }

    [Fact]
    public void TestFindMasIsACross()
    {
        var grid = new List<List<Letter>>()
        {
            new List<Letter> { new M(), new X(), new S()},
            new List<Letter> { new X(), new A(), new X()},
            new List<Letter> { new M(), new X(), new S()},
        };

        grid = Day4.JoinGrid(grid);

        Assert.Equal(1, Day4.MasXCount(grid));
    }

}