namespace Simulator.Maps;

public class SmallMap : Map
{
    private List<IMappable>?[,] _creaturesArray;

    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20)
            throw new ArgumentOutOfRangeException("Max size = 20");

        _creaturesArray = new List<IMappable>[sizeX, sizeY];
    }

    public override void Add(IMappable creature, Point position)
    {
        if (!Exists(position))
            throw new ArgumentException("Point doesnt belong to map!");

        if (_creaturesArray[position.X, position.Y] is null || _creaturesArray[position.X, position.Y]?.Count == 0)
            _creaturesArray[position.X, position.Y] = new() { creature };
        else
            _creaturesArray[position.X, position.Y]?.Add(creature);

        creature.Initialize(this, position, false);
    }

    public override void Remove(IMappable creature, Point position)
    {
        var creatures = _creaturesArray[position.X, position.Y];

        if (creatures is null || !creatures.Contains(creature))
            return;

        _creaturesArray[position.X, position.Y]?.Remove(creature);
        creature.ClearMap();
    }

    public override List<IMappable>? At(int posX, int posY)
    {
        return At(new Point(posX, posY));
    }

    public override List<IMappable>? At(Point position)
    {
        if (!Exists(position))
            return null;

        var creatures = new List<IMappable>();

        foreach (var creature in _creaturesArray[position.X, position.Y] ?? [])
            creatures.Add(creature);

        return creatures;
    }

    public override Point Next(Point p, Direction d)
    {
        throw new NotImplementedException();
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        throw new NotImplementedException();
    }
}
