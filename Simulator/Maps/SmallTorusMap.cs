namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; set; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException("Allowed range: [5, 20]");

        Size = size;
    }

    public override bool Exist(Point p)
    {
        return new Rectangle(new Point(0, 0), new Point(Size - 1, Size - 1)).Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => new Point(p.X, (p.Y + 1) % Size),
            Direction.Down => new Point(p.X, (p.Y - 1 + Size) % Size),
            Direction.Left => new Point((p.X - 1 + Size) % Size, p.Y),
            _ => new Point((p.X + 1) % Size, p.Y)
        };
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => new Point((p.X + 1) % Size, (p.Y + 1) % Size),
            Direction.Right => new Point((p.X + 1) % Size, (p.Y - 1 + Size) % Size),
            Direction.Down => new Point((p.X - 1 + Size) % Size, (p.Y - 1 + Size) % Size),
            _ => new Point((p.X - 1 + Size) % Size, (p.Y + 1) % Size)
        };
    }
}
