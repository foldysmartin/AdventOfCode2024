
public class Day4
{
    public static Letter ConvertToLetter(char c)
    {
        c = char.ToUpper(c);
        switch (c)
        {
            case 'A':
                return new A();
            case 'X':
                return new X();
            case 'M':
                return new M();
            case 'S':
                return new S();
            default:
                throw new ArgumentException("Invalid letter");
        }
    }


    // Warning the input grid will be modified
    public static List<List<Letter>> JoinGrid(List<List<Letter>> grid)
    {
        // Assert all rows have the same length
        if (grid.Select(row => row.Count).Distinct().Count() != 1)
        {
            throw new ArgumentException("All rows must have the same length");
        }


        for (int i = 0; i < grid.Count; i++)
        {
            for (int j = 0; j < grid[i].Count; j++)
            {
                //Create right and left links
                if (j + 1 < grid[i].Count)
                {
                    grid[i][j].Right = grid[i][j + 1];
                    grid[i][j + 1].Left = grid[i][j];
                }

                //Create up and down links
                if (i + 1 < grid.Count)
                {
                    grid[i][j].Down = grid[i + 1][j];
                    grid[i + 1][j].Up = grid[i][j];
                }

                //Create right down link and left up link
                if (i + 1 < grid.Count && j + 1 < grid[i].Count)
                {
                    grid[i][j].RightDown = grid[i + 1][j + 1];
                    grid[i + 1][j + 1].LeftUp = grid[i][j];
                }

                //Create left down link and right up link
                if (i + 1 < grid.Count && j - 1 >= 0)
                {
                    grid[i][j].LeftDown = grid[i + 1][j - 1];
                    grid[i + 1][j - 1].RightUp = grid[i][j];
                }

            }
        }

        return grid;
    }

    public static int XmasCount(List<List<Letter>> grid)
    {
        return grid.Sum(row => row.Sum(letter => letter.XmasCount()));
    }

    public static int MasXCount(List<List<Letter>> grid)
    {
        return grid.Sum(row => row.Count(letter => letter.IsMasInX()));
    }
}

public enum Directions
{
    LeftUp,
    Up,
    RightUp,
    Left,
    Right,
    LeftDown,
    Down,
    RightDown
}

public enum Letters
{
    A = 1,
    X = 8,
    M = 13,
    S = 19
}

public abstract class Letter
{
    public Letter? LeftUp { get; internal set; } = null;
    public Letter? Up { get; internal set; } = null;
    public Letter? RightUp { get; internal set; } = null;
    public Letter? Left { get; internal set; } = null;
    public Letter? Right { get; internal set; } = null;
    public Letter? LeftDown { get; internal set; } = null;
    public Letter? Down { get; internal set; } = null;
    public Letter? RightDown { get; internal set; } = null;

    public abstract Letters letter();


    internal abstract bool IsXmas(Directions direction);

    protected bool IsXmas(Directions direction, Letters nextLetter)
    {
        return direction switch
        {
            Directions.LeftUp => LeftUp != null && LeftUp.letter() == nextLetter && LeftUp.IsXmas(direction),
            Directions.Up => Up != null && Up.letter() == nextLetter && Up.IsXmas(direction),
            Directions.RightUp => RightUp != null && RightUp.letter() == nextLetter && RightUp.IsXmas(direction),
            Directions.Left => Left != null && Left.letter() == nextLetter && Left.IsXmas(direction),
            Directions.Right => Right != null && Right.letter() == nextLetter && Right.IsXmas(direction),
            Directions.LeftDown => LeftDown != null && LeftDown.letter() == nextLetter && LeftDown.IsXmas(direction),
            Directions.Down => Down != null && Down.letter() == nextLetter && Down.IsXmas(direction),
            Directions.RightDown => RightDown != null && RightDown.letter() == nextLetter && RightDown.IsXmas(direction),
            _ => throw new NotImplementedException(),
        };
    }

    internal virtual bool IsMasInX()
    {
        return false;
    }


    internal virtual int XmasCount()
    {
        return 0;
    }
}

public class A : Letter
{
    public override Letters letter()
    {
        return Letters.A;
    }

    internal override bool IsXmas(Directions direction)
    {
        return IsXmas(direction, Letters.S);
    }

    internal override bool IsMasInX()
    {
        var leftToRight = new List<Letters?>() { LeftUp?.letter(), RightDown?.letter() };
        var rightToLeft = new List<Letters?>() { RightUp?.letter(), LeftDown?.letter() };

        var isLeftToRight = leftToRight.Contains(Letters.M) && leftToRight.Contains(Letters.S);
        var isRightToLeft = rightToLeft.Contains(Letters.M) && rightToLeft.Contains(Letters.S);

        return isLeftToRight && isRightToLeft;
    }
}

public class X : Letter
{
    public override Letters letter()
    {
        return Letters.X;
    }

    internal override int XmasCount()
    {
        return Enum.GetValues(typeof(Directions)).Cast<Directions>().Count(IsXmas);

    }

    internal override bool IsXmas(Directions direction)
    {
        return IsXmas(direction, Letters.M);
    }
}

public class M : Letter
{
    public override Letters letter()
    {
        return Letters.M;
    }

    internal override bool IsXmas(Directions direction)
    {
        return IsXmas(direction, Letters.A);
    }
}

public class S : Letter
{
    public override Letters letter()
    {
        return Letters.S;
    }

    internal override bool IsXmas(Directions direction)
    {
        return true;
    }
}