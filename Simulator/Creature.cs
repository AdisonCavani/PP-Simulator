using Simulator.Maps;

namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown";
    private int _level;

    public abstract int Power { get; }
    public abstract string Info { get; }

    public Map? Map { get; set; }

    public Point Position { get; set; }

    public string Name
    {
        get => _name;
        init => _name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => _level;
        init => _level = Validator.Limiter(value, 1, 10);
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {

    }

    public abstract string Greeting();

    public void Upgrade()
    {
        if (_level < 10)
            _level++;
    }

    public string Go(Direction direction)
    {
        if (Map is null)
            return $"Creature '{Name}' is not on any map";

        Map.Move(this, Position, Map.Next(Position, direction));
        return direction.ToString().ToLower();
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Name} [{Level}]{Info}";
    }

    public void Initialize(Map map, Point position, bool initializeMap)
    {
        Map = map;
        Position = position;

        if (initializeMap)
            Map.Add(this, position);
    }

    public void ClearMap()
    {
        Map = null;
    }
}
