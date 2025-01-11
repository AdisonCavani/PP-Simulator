namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{

    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {

    }

    public override Point Next(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => new Point(p.X, (p.Y + 1) % SizeY),
            Direction.Down => new Point(p.X, (p.Y - 1 + SizeY) % SizeY),
            Direction.Left => new Point((p.X - 1 + SizeX) % SizeX, p.Y),
            _ => new Point((p.X + 1) % SizeX, p.Y)
        };
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => new Point((p.X + 1) % SizeX, (p.Y + 1) % SizeY),
            Direction.Right => new Point((p.X + 1) % SizeX, (p.Y - 1 + SizeY) % SizeY),
            Direction.Down => new Point((p.X - 1 + SizeX) % SizeX, (p.Y - 1 + SizeY) % SizeY),
            _ => new Point((p.X - 1 + SizeX) % SizeX, (p.Y + 1) % SizeY)
        };
    }
}
