using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string _description = "Unknown";
    public required string Description
    {
        get => _description;
        init => _description = Validator.Shortener(value, 3, 15, '#');
    }

    public uint Size { get; set; } = 3;
    public virtual string Info { get; }

    public Map? Map { get; set; }

    public Point Position { get; set; }

    public virtual string Go(Direction direction)
    {
        if (Map is null)
            return $"Animal '{Description}' is not on any map";

        Map.Move(this, Position, Map.Next(Position, direction));
        return direction.ToString().ToLower();
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

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Description} {Info}<{Size}>";
}

