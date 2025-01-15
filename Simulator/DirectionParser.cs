namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string input)
    {
        List<Direction> directions = new();

        foreach (char letter in input.ToUpper())
        {
            if (letter == 'U')
                directions.Add(Direction.Up);
            else if (letter == 'R')
                directions.Add(Direction.Right);
            else if (letter == 'D')
                directions.Add(Direction.Down);
            else if (letter == 'L')
                directions.Add(Direction.Left);
        }

        return directions.ToArray();
    }

    public static string ParseStr(string? input)
    {
        var allowedChars = new char[] { 'U', 'R', 'D', 'L' };
        return new string(input?.ToUpper().Where(c => allowedChars.Contains(c)).ToArray());
    }
}
