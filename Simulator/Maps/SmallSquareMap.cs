namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size { get; set; }

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException("Allowed range: [5, 20]");

        Size = size;
    }

    public override bool Exist(Point p)
    {
        return new Rectangle(0, 0, Size - 1, Size - 1).Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);

        if (!Exist(nextPoint))
            return p;

        return nextPoint;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextPoint = p.NextDiagonal(d);

        if (!Exist(nextPoint))
            return p;

        return nextPoint;
    }
}
