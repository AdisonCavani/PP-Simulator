namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public int Size { get; set; }

    public SmallSquareMap(int size) : base(size, size)
    {
        Size = size;
    }

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);

        if (!Exists(nextPoint))
            return p;

        return nextPoint;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextPoint = p.NextDiagonal(d);

        if (!Exists(nextPoint))
            return p;

        return nextPoint;
    }
}
